using Logic.Levels;
using Services.PersistentProgress;
using Services.StaticData;
using UnityEngine;

namespace Logic.StateMachine.States
{
    public class InitialState : BaseStates
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPersistentProgressService _progressService;
        
        private readonly ArrangementOfCards _arrangementOfCards;
        private readonly CardSelection _cardSelection;
        
        public InitialState(StateMachine stateMachine, IStaticDataService staticDataService, IPersistentProgressService progressService,
            ArrangementOfCards arrangementOfCards, CardSelection cardSelection) : base(stateMachine)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _arrangementOfCards = arrangementOfCards;
            _cardSelection = cardSelection;
        }

        public override void Enter()
        {
            int level = _progressService.GetUserProgress.Level;
            TypesOfFormations type = _staticDataService.GetLevels().Levels[level - 1].Formation;
            _arrangementOfCards.Construct(_cardSelection);
            _arrangementOfCards.EnableSelectedArrangement(type);
            _arrangementOfCards.LoadAndInstantiatePrefabs(_staticDataService.GetLevels().Levels[level - 1].Cards);
            _cardSelection.SetNumberOfCards(_staticDataService.GetLevels().Levels[level - 1].Cards.Count);
        }
        
        public override void Exit()
        {
        }
    }
}