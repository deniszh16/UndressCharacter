using Logic.Levels;
using Services.PersistentProgress;
using Services.StaticData;

namespace Logic.StateMachine.States
{
    public class InitialState : BaseStates
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPersistentProgressService _progressService;
        private readonly ArrangementOfCards _arrangementOfCards;
        
        public InitialState(StateMachine stateMachine, IStaticDataService staticDataService, IPersistentProgressService progressService,
            ArrangementOfCards arrangementOfCards) : base(stateMachine)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _arrangementOfCards = arrangementOfCards;
        }

        public override void Enter()
        {
            int level = _progressService.GetUserProgress.Level;
            TypesOfFormations type = _staticDataService.GetLevels().Levels[level].Formation;
            _arrangementOfCards.EnableSelectedArrangement(type);
            _arrangementOfCards.LoadAndInstantiatePrefabs(_staticDataService.GetLevels().Levels[level].Cards);
        }
        
        public override void Exit()
        {
        }
    }
}