using Logic.Levels;
using Logic.UI.ListOfCharacters;
using Services.PersistentProgress;
using Services.SaveLoad;

namespace Logic.StateMachine.States
{
    public class CompletedState : BaseStates
    {
        private const int Hearts = 50;

        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        
        private readonly GamePause _gamePause;
        private readonly CharacterProgress _characterProgress;
        private readonly LevelResults _levelResults;

        public CompletedState(StateMachine stateMachine, IPersistentProgressService progressService,
            ISaveLoadService saveLoadService, GamePause gamePause, CharacterProgress characterProgress,
            LevelResults levelResults) : base(stateMachine)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _gamePause = gamePause;
            _characterProgress = characterProgress;
            _levelResults = levelResults;
        }

        public override void Enter()
        {
            _gamePause.ChangeButtonVisibility(visibility: false);
            _levelResults.ShowVictoryPanel();
            _levelResults.RewardIncreased += UpdateProgress;
            IncreaseLevelProgress();
            UpdateProgress();
        }

        private void IncreaseLevelProgress() =>
            _progressService.GetUserProgress.Level += 1;

        private void UpdateProgress()
        {
            _progressService.GetUserProgress.GetCurrentCharacter().CharacterHearts += Hearts;
            _characterProgress.UpdateSliderValue();
            _saveLoadService.SaveProgress();
            CheckCharacterProgress();
        }

        private void CheckCharacterProgress()
        {
            if (!_characterProgress.CheckCharacterProgress()) return;
            _levelResults.ShowCharacterUnlock();
            _progressService.GetUserProgress.GetCurrentCharacter().CharacterStage += 1;
            _progressService.GetUserProgress.GetCurrentCharacter().CharacterHearts = 0;

            if (_progressService.GetUserProgress.GetCurrentCharacter().CharacterStage >= 4)
                _progressService.GetUserProgress.UnlockNextCharacter();
            
            _saveLoadService.SaveProgress();
        }

        public override void Exit()
        {
        }
    }
}