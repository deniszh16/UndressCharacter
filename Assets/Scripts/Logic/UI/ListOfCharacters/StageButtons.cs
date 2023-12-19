using Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Logic.UI.ListOfCharacters
{
    public class StageButtons : MonoBehaviour
    {
        [Header("Кнопки этапов")]
        [SerializeField] private StageButton[] _buttons;
        
        private IPersistentProgressService _progressService;
        private CurrentCharacter _currentCharacter;

        [Inject]
        private void Construct(IPersistentProgressService progressService, CurrentCharacter currentCharacter)
        {
            _progressService = progressService;
            _currentCharacter = currentCharacter;
        }

        private void Start() =>
            RefreshButtons();

        public void RefreshButtons()
        {
            int characterProgress = _progressService.GetUserProgress.GetCurrentCharacter().CharacterStage;
            for (int i = 0; i < _buttons.Length; i++)
                _buttons[i].ChangeButtonActivity(state: _buttons[i].Number <= characterProgress);
        }

        public void SelectAnotherStage(StageButton stageButton) =>
            _currentCharacter.ShowCurrentCharacter(lastImage: false, stageButton.Number);
    }
}