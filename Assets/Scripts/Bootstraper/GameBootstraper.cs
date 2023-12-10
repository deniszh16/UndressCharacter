using Services.PersistentProgress;
using Services.SceneLoader;
using Services.SaveLoad;
using UnityEngine;
using Zenject;
using Data;

namespace Bootstraper
{
    public class GameBootstraper : MonoBehaviour
    {
        private IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private ISceneLoaderService _sceneLoaderService;
        
        [Inject]
        private void Construct(IPersistentProgressService progressService, ISaveLoadService saveLoadService,
            ISceneLoaderService sceneLoaderService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _sceneLoaderService = sceneLoaderService;
        }
        
        private void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            LoadProgressOrInitNew();
            _sceneLoaderService.LoadSceneAsync(Scenes.MainMenu, screensaver: false, delay: 1.5f);
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.GetUserProgress =
                _saveLoadService.LoadProgress() ?? new UserProgress();
        }
    }
}