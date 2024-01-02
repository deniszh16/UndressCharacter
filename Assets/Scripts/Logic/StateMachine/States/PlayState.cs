using Logic.Levels;
using Services.Sound;

namespace Logic.StateMachine.States
{
    public class PlayState : BaseStates
    {
        private readonly ISoundService _soundService;
        private readonly LevelTimer _levelTimer;
        private readonly CardSelection _cardSelection;
        
        public PlayState(StateMachine stateMachine, ISoundService soundService, LevelTimer levelTimer,
            CardSelection cardSelection) : base(stateMachine)
        {
            _soundService = soundService;
            _levelTimer = levelTimer;
            _cardSelection = cardSelection;
        }

        public override void Enter()
        {
            _levelTimer.ChangeTimerVisibility(state: true);
            _levelTimer.TimerCompleted += OnLevelLost;
            _levelTimer.StartTimer();
            _cardSelection.AllCardsFound += OnLevelPassed;
            _soundService.SettingBackgroundMusic();
        }
        
        private void OnLevelPassed()
        {
            if (_levelTimer.CurrentSeconds > 0)
                _stateMachine.Enter<CompletedState>();
        }

        private void OnLevelLost() =>
            _stateMachine.Enter<LosingState>();

        public override void Exit()
        {
            _levelTimer.StopTimer();
            _levelTimer.TimerCompleted -= OnLevelLost;
            _levelTimer.ChangeTimerVisibility(state: false);
            _cardSelection.AllCardsFound -= OnLevelPassed;
        }
    }
}