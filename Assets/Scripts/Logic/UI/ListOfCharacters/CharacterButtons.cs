using Services.PersistentProgress;
using Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Logic.UI.ListOfCharacters
{
    public class CharacterButtons : MonoBehaviour
    {
        [Header("Кнопки персонажей")]
        [SerializeField] private CharacterButton[] _buttons;
        
        private IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private CurrentCharacter _currentCharacter;
        private CharacterProgress _characterProgress;
        private StageButtons _stageButtons;

        [Inject]
        private void Construct(IPersistentProgressService progressService, ISaveLoadService saveLoadService,
            CurrentCharacter currentCharacter, CharacterProgress characterProgress, StageButtons stageButtons)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _currentCharacter = currentCharacter;
            _characterProgress = characterProgress;
            _stageButtons = stageButtons;
        }

        private void Start() =>
            RefreshButtons();

        private void RefreshButtons()
        {
            for (int i = 0; i < _progressService.GetUserProgress.Characters.Count; i++)
            {
                bool activity = _progressService.GetUserProgress.Characters[i].Activity;
                _buttons[i].ChangeButtonActivity(activity);
            }
        }

        public void SelectCharacter(CharacterButton characterButton)
        {
            if (_progressService.GetUserProgress.CurrentCharacter != characterButton.Number)
            {
                _progressService.GetUserProgress.CurrentCharacter = characterButton.Number;
                _saveLoadService.SaveProgress();
                _currentCharacter.ShowCurrentCharacter(lastImage: true);
                _stageButtons.RefreshButtons();
                _characterProgress.UpdateSliderValue();
            }
        }
    }
}