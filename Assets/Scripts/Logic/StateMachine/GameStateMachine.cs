using Logic.Levels;
using Logic.StateMachine.States;
using Logic.UI.ListOfCharacters;
using Services.PersistentProgress;
using Services.SaveLoad;
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
        private ISaveLoadService _saveLoadService;

        private ArrangementOfCards _arrangementOfCards;
        private CardSelection _cardSelection;
        private LevelTimer _levelTimer;

        private GamePause _gamePause;
        private CharacterProgress _characterProgress;
        private LevelResults _levelResults;

        [Inject]
        private void Construct(StateMachine stateMachine, IStaticDataService staticDataService, IPersistentProgressService progressService,
            ISaveLoadService saveLoadService, ArrangementOfCards arrangementOfCards, CardSelection cardSelection,
            LevelTimer levelTimer, GamePause gamePause, CharacterProgress characterProgress, LevelResults levelResults)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _arrangementOfCards = arrangementOfCards;
            _cardSelection = cardSelection;
            _levelTimer = levelTimer;
            _gamePause = gamePause;
            _characterProgress = characterProgress;
            _levelResults = levelResults;
        }

        private void Awake()
        {
            _stateMachine.AddState(new InitialState(_stateMachine, _staticDataService, _progressService, _arrangementOfCards, _cardSelection, _levelTimer));
            _stateMachine.AddState(new PlayState(_stateMachine, _levelTimer, _cardSelection));
            _stateMachine.AddState(new PauseState(_stateMachine, _gamePause));
            _stateMachine.AddState(new LosingState(_stateMachine, _gamePause, _levelResults));
            _stateMachine.AddState(new CompletedState(_stateMachine, _progressService, _saveLoadService, _gamePause, _characterProgress, _levelResults));
        }

        private void Start() =>
            _stateMachine.Enter<InitialState>();
    }
}