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

        [Inject]
        private void Construct(StateMachine stateMachine, IStaticDataService staticDataService,
            IPersistentProgressService progressService, ArrangementOfCards arrangementOfCards)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
            _progressService = progressService;
            _arrangementOfCards = arrangementOfCards;
        }

        private void Awake()
        {
            _stateMachine.AddState(new InitialState(_stateMachine, _staticDataService, _progressService, _arrangementOfCards));
        }

        private void Start() =>
            _stateMachine.Enter<InitialState>();
    }
}