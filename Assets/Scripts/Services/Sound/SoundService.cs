using System;
using Services.PersistentProgress;
using Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Services.Sound
{
    public class SoundService : MonoBehaviour, ISoundService
    {
        [Header("Фоновая музыка")]
        [SerializeField] private AudioSource _audioSourceBackgroundMusic;
        [SerializeField] private AudioClip[] _audioClips;
        
        [Header("Игровые звуки")]
        [SerializeField] private AudioSource _audioSourceSounds;
        [SerializeField] private AudioClip[] _uiSounds;
        
        public bool SoundActivity { get; set; }
        
        public event Action SoundChanged;
        
        private IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        
        [Inject]
        private void Construct(IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }
        
        public void SwitchSound()
        {
            bool activity = _progressService.GetUserProgress.Sound;
            SoundActivity = !activity;

            _progressService.GetUserProgress.Sound = SoundActivity;
            _saveLoadService.SaveProgress();
            
            SoundChanged?.Invoke();
            SettingBackgroundMusic();
        }

        public void SettingBackgroundMusic()
        {
            if (SoundActivity)
            {
                if (_audioSourceBackgroundMusic.isPlaying == false)
                {
                    int randomMusic = UnityEngine.Random.Range(0, _audioClips.Length);
                    _audioSourceBackgroundMusic.clip = _audioClips[randomMusic];
                    _audioSourceBackgroundMusic.Play();
                }
            }
            else
            {
                _audioSourceBackgroundMusic.Stop();
            }
        }

        public void StopBackgroundMusic() =>
            _audioSourceBackgroundMusic.Stop();

        public void PlaySound(Sounds sound)
        {
            if (SoundActivity)
            {
                if (_audioSourceSounds.isPlaying)
                    return;
                
                _audioSourceSounds.clip = _uiSounds[(int)sound];
                _audioSourceSounds.Play();
            }
        }
    }
}