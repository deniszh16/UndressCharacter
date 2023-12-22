using Logic.Levels;
using Logic.StateMachine.States;
using Services.PersistentProgress;
using Services.StaticData;
using UnityEngine;
using Zenject;

namespace Logic.StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private IStaticDataService _staticDataService;
        private IPersistentProgressService _progressService;

        private ArrangementOfCards _arrangementOfCards;
        private CardSelection _cardSelection;

        [Inject]
        private void Construct(StateMachine stateMachine, IStaticDataService staticDataService,
            IPersistentProgressService progressService, ArrangementOfCards arrangementOfCards, CardSelection cardSelection)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
            _progressService = progressService;
            _arrangementOfCards = arrangementOfCards;
            _cardSelection = cardSelection;
        }

        private void Awake()
        {
            _stateMachine.AddState(new InitialState(_stateMachine, _staticDataService, _progressService, _arrangementOfCards, _cardSelection));
            _stateMachine.AddState(new PlayState(_stateMachine));
        }

        private void Start() =>
            _stateMachine.Enter<InitialState>();
    }
}