using Logic.Levels;

namespace Logic.StateMachine.States
{
    public class PauseState : BaseStates
    {
        private readonly GamePause _gamePause;
        
        public PauseState(StateMachine stateMachine, GamePause gamePause)
            : base(stateMachine) => _gamePause = gamePause;

        public override void Enter()
        {
            _gamePause.ChangeButtonVisibility(visibility: false);
            _gamePause.ChangePausePanelVisibility(visibility: true);
        }

        public override void Exit()
        {
            _gamePause.ChangePausePanelVisibility(visibility: false);
            _gamePause.ChangeButtonVisibility(visibility: true);
        }
    }
}