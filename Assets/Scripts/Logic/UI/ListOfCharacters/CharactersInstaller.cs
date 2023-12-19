using UnityEngine;
using Zenject;

namespace Logic.UI.ListOfCharacters
{
    public class CharactersInstaller : MonoInstaller
    {
        [SerializeField] private CurrentCharacter _currentCharacter;
        [SerializeField] private StageButtons _stageButtons;
        [SerializeField] private CharacterProgress _characterProgress;
        
        public override void InstallBindings()
        {
            BindCurrentCharacter();
            BindStageButtons();
            BindCharacterProgress();
        }

        private void BindCurrentCharacter() =>
            Container.BindInstance(_currentCharacter).AsSingle();

        private void BindStageButtons() =>
            Container.BindInstance(_stageButtons).AsSingle();

        private void BindCharacterProgress() =>
            Container.BindInstance(_characterProgress).AsSingle();
    }
}