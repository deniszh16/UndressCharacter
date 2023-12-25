using Logic.UI.ListOfCharacters;
using UnityEngine;
using Zenject;

namespace Logic.Levels
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private ArrangementOfCards _arrangementOfCards;
        [SerializeField] private CardSelection _cardSelection;
        [SerializeField] private LevelTimer _levelTimer;

        [SerializeField] private GamePause _gamePause;
        [SerializeField] private CharacterProgress _characterProgress;
        [SerializeField] private LevelResults _levelResults;
        
        public override void InstallBindings()
        {
            BindStateMachine();
            BindArrangementOfCards();
            BindCardSelection();
            BindLevelTimer();
            BindGamePause();
            BindCharacterProgress();
            LevelResults();
        }

        private void BindStateMachine()
        {
            StateMachine.StateMachine stateMachine = new StateMachine.StateMachine();
            Container.BindInstance(stateMachine).AsSingle();
        }

        private void BindArrangementOfCards() =>
            Container.BindInstance(_arrangementOfCards).AsSingle();

        private void BindCardSelection() =>
            Container.BindInstance(_cardSelection).AsSingle();

        private void BindLevelTimer() =>
            Container.BindInstance(_levelTimer).AsSingle();

        private void BindGamePause() =>
            Container.BindInstance(_gamePause).AsSingle();

        private void BindCharacterProgress() =>
            Container.BindInstance(_characterProgress).AsSingle();

        private void LevelResults() =>
            Container.BindInstance(_levelResults).AsSingle();
    }
}