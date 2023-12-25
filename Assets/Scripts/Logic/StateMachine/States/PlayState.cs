using Logic.Levels;

namespace Logic.StateMachine.States
{
    public class PlayState : BaseStates
    {
        private readonly LevelTimer _levelTimer;
        private readonly CardSelection _cardSelection;
        
        public PlayState(StateMachine stateMachine, LevelTimer levelTimer,
            CardSelection cardSelection) : base(stateMachine)
        {
            _levelTimer = levelTimer;
            _cardSelection = cardSelection;
        }

        public override void Enter()
        {
            _levelTimer.ChangeTimerVisibility(state: true);
            _levelTimer.TimerCompleted += OnLevelLost;
            _levelTimer.StartTimer();
            _cardSelection.AllCardsFound += OnLevelPassed;
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