using System.Collections.Generic;
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

        [Inject]
        private void Construct(IPersistentProgressService progressService) =>
            _progressService = progressService;

        private void Start() =>
            ShowCurrentCharacter(lastImage: true);

        public void ShowCurrentCharacter(bool lastImage, int selectedOption = 0)
        {
            _character = _progressService.GetUserProgress.CurrentCharacter - 1;
            _progress = lastImage
                ? _progressService.GetUserProgress.GetCurrentCharacter().CharacterStage
                : selectedOption;
            
            _image.sprite = _characters[_character].Clothes[_progress];
        }
    }
}