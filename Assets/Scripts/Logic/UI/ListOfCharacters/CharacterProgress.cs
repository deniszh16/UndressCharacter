using Services.PersistentProgress;
using Services.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Logic.UI.ListOfCharacters
{
    public class CharacterProgress : MonoBehaviour
    {
        [Header("Слайдер")]
        [SerializeField] private Slider _slider;

        [Header("Проценты прогресса")]
        [SerializeField] private ProgressPercentages _progressPercentages;

        private int _currentCharacter;
        private int _currentStage;
        private int _currentHearts;
        private int _target;

        private IPersistentProgressService _progressService;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IPersistentProgressService progressService, IStaticDataService staticDataService)
        {
            _progressService = progressService;
            _staticDataService = staticDataService;
        }

        private void Start() =>
            UpdateSliderValue();

        public void UpdateSliderValue()
        {
            _currentCharacter = _progressService.GetUserProgress.CurrentCharacter;
            _currentStage = _progressService.GetUserProgress.GetCurrentCharacter().CharacterStage;
            _currentHearts = _progressService.GetUserProgress.GetCurrentCharacter().CharacterHearts;
            _target = _staticDataService.GetCharacters(_currentCharacter).NumberOfHearts[_currentStage];
            
            float clampedValue = Mathf.Clamp(value: _currentHearts, min: 0f, max: _target);
            _slider.value = clampedValue / _target;;
            
            int  percentages = (int)(clampedValue / _target * 100);
            if (percentages < 0) percentages = 0;
            if (percentages > 100) percentages = 100;
            _progressPercentages.RecordProgressPercentages(percentages);
        }

        public bool CheckCharacterProgress() =>
            _currentHearts >= _target;
    }
}