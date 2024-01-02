using Services.Sound;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Logic.UI.Buttons
{
    public class StartButton : MonoBehaviour
    {
        [Header("Компонент кнопки")]
        [SerializeField] private Button _button;

        private ISoundService _soundService;

        [Inject]
        private void Construct(ISoundService soundService) =>
            _soundService = soundService;

        public void ChangeButtonActivity(bool state) =>
            _button.interactable = state;

        public void MuteSoundBeforeLoading() =>
            _soundService.StopBackgroundMusic();
    }
}