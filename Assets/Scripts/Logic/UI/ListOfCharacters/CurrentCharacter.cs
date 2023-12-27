using System.Collections.Generic;
using Logic.UI.Buttons;
using Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Logic.UI.ListOfCharacters
{
    public class CurrentCharacter : MonoBehaviour
    {
        [Header("Список персонажей")]
        [SerializeField] private List<Character> _characters;

        [Header("Компоненты объекта")]
        [SerializeField] private Image _image;

        private int _character;
        private int _progress;

        private IPersistentProgressService _progressService;
        private StartButton _startButton;

        [Inject]
        private void Construct(IPersistentProgressService progressService, StartButton startButton)
        {
            _progressService = progressService;
            _startButton = startButton;
        }

        private void Start() =>
            ShowCurrentCharacter(lastImage: true);

        public void ShowCurrentCharacter(bool lastImage, int selectedOption = 0)
        {
            _character = _progressService.GetUserProgress.CurrentCharacter - 1;
            _progress = lastImage
                ? _progressService.GetUserProgress.GetCurrentCharacter().CharacterStage - 1
                : selectedOption;

            bool buttonState = _progressService.GetUserProgress.GetCurrentCharacter().CharacterStage - 1 < 3;
            _startButton.ChangeButtonActivity(buttonState);
            
            _image.sprite = _characters[_character].Clothes[_progress];
        }
    }
}