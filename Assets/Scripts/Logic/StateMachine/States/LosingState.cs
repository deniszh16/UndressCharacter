using Logic.Levels;
using Services.Sound;

namespace Logic.StateMachine.States
{
    public class LosingState : BaseStates
    {
        private readonly ISoundService _soundService;
        private readonly GamePause _gamePause;
        private readonly LevelResults _levelResults;
        
        public LosingState(StateMachine stateMachine, ISoundService soundService, GamePause gamePause,
            LevelResults levelResults) : base(stateMachine)
        {
            _soundService = soundService;
            _gamePause = gamePause;
            _levelResults = levelResults;
        }

        public override void Enter()
        {
            _gamePause.ChangeButtonVisibility(visibility: false);
            _levelResults.ShowLossPanel(visibility: true);
            _soundService.StopBackgroundMusic();
            _soundService.PlaySound(Services.Sound.Sounds.Losing);
        }

        public override void Exit()
        {
        }
    }
}