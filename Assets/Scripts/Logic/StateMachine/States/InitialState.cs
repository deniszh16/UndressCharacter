using Logic.Levels;
using Logic.StaticData;
using Services.PersistentProgress;
using Services.StaticData;

namespace Logic.StateMachine.States
{
    public class InitialState : BaseStates
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPersistentProgressService _progressService;
        
        private readonly ArrangementOfCards _arrangementOfCards;
        private readonly CardSelection _cardSelection;
        private readonly LevelTimer _levelTimer;
        
        public InitialState(StateMachine stateMachine, IStaticDataService staticDataService, IPersistentProgressService progressService,
            ArrangementOfCards arrangementOfCards, CardSelection cardSelection,
            LevelTimer levelTimer) : base(stateMachine)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _arrangementOfCards = arrangementOfCards;
            _cardSelection = cardSelection;
            _levelTimer = levelTimer;
        }

        public override void Enter()
        {
            int level = _progressService.GetUserProgress.Level;
            LevelOptions levelOptions = _staticDataService.GetLevels().Levels[level - 1];
            _arrangementOfCards.Construct(_cardSelection, levelOptions.CardSize);
            _arrangementOfCards.EnableSelectedArrangement(levelOptions.Formation);
            _arrangementOfCards.LoadAndInstantiatePrefabs(levelOptions.Cards);
            _cardSelection.SetNumberOfCards(levelOptions.Cards.Count);
            _levelTimer.SetTimer(levelOptions.Seconds);
            GoToGameState();
        }

        private void GoToGameState() =>
            _stateMachine.Enter<PlayState>();

        public override void Exit()
        {
        }
    }
}