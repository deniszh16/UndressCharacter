using UnityEngine;
using Zenject;

namespace Logic.Levels
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private ArrangementOfCards _arrangementOfCards;
        
        public override void InstallBindings()
        {
            BindStateMachine();
            BindArrangementOfCards();
        }

        private void BindStateMachine()
        {
            StateMachine.StateMachine stateMachine = new StateMachine.StateMachine();
            Container.BindInstance(stateMachine).AsSingle();
        }

        private void BindArrangementOfCards() =>
            Container.BindInstance(_arrangementOfCards).AsSingle();
    }
}