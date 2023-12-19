using UnityEngine;
using UnityEngine.Localization;
using TMPro;

namespace Logic.UI.ListOfCharacters
{
    public class ProgressPercentages : MonoBehaviour
    {
        [Header("Текстовый компонент")]
        [SerializeField] private LocalizedString _localizedString;
        [SerializeField] private TextMeshProUGUI _textComponent;

        private int _percentages;

        private void OnEnable()
        {
            _localizedString.Arguments = new object[] { _percentages };
            _localizedString.StringChanged += UpdateText;
        }

        private void UpdateText(string value) =>
            _textComponent.text = value;

        public void RecordProgressPercentages(int value)
        {
            _percentages = value;
            _localizedString.Arguments[0] = _percentages;
            _localizedString.RefreshString();
        }

        private void OnDisable() =>
            _localizedString.StringChanged -= UpdateText;
    }
}