using Logic.Levels;
using Services.Sound;

namespace Logic.StateMachine.States
{
    public class PauseState : BaseStates
    {
        private readonly GamePause _gamePause;
        private readonly ISoundService _soundService;
        
        public PauseState(StateMachine stateMachine, GamePause gamePause, ISoundService soundService)
            : base(stateMachine)
        {
            _gamePause = gamePause;
            _soundService = soundService;
        }

        public override void Enter()
        {
            _gamePause.ChangeButtonVisibility(visibility: false);
            _gamePause.ChangePausePanelVisibility(visibility: true);
            _soundService.StopBackgroundMusic();
        }

        public override void Exit()
        {
            _gamePause.ChangePausePanelVisibility(visibility: false);
            _gamePause.ChangeButtonVisibility(visibility: true);
        }
    }
}