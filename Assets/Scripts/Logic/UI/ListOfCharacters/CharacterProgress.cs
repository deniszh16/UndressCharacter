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
            int currentCharacter = _progressService.GetUserProgress.CurrentCharacter;
            int currentStage = _progressService.GetUserProgress.GetCurrentCharacter().CharacterStage;
            int currentHearts = _progressService.GetUserProgress.GetCurrentCharacter().CharacterHearts;
            int target = _staticDataService.GetCharacters(currentCharacter).NumberOfHearts[currentStage - 1];

            float clampedValue = Mathf.Clamp(value: currentHearts, min: 0f, max: target);
            _slider.value = clampedValue / target;

            int  percentages = (int)(clampedValue / target * 100);
            _progressPercentages.RecordProgressPercentages(percentages);
        }
    }
}