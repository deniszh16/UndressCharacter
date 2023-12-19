using UnityEngine;
using UnityEngine.UI;

namespace Logic.UI.ListOfCharacters
{
    public class StageButton : MonoBehaviour
    {
        [Header("Номер кнопки")]
        [SerializeField] private int _number;

        [Header("Компонент кнопки")]
        [SerializeField] private Button _button;

        public int Number => _number;

        public void ChangeButtonActivity(bool state) =>
            _button.interactable = state;
    }
}