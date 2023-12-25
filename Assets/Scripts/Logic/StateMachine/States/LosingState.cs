using Logic.Levels;

namespace Logic.StateMachine.States
{
    public class LosingState : BaseStates
    {
        private readonly GamePause _gamePause;
        private readonly LevelResults _levelResults;
        
        public LosingState(StateMachine stateMachine, GamePause gamePause,
            LevelResults levelResults) : base(stateMachine)
        {
            _gamePause = gamePause;
            _levelResults = levelResults;
        }

        public override void Enter()
        {
            _gamePause.ChangeButtonVisibility(visibility: false);
            _levelResults.ShowLossPanel(visibility: true);
        }

        public override void Exit()
        {
        }
    }
}