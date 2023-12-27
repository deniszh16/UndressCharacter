using UnityEngine;
using UnityEngine.UI;

namespace Logic.UI.Buttons
{
    public class StartButton : MonoBehaviour
    {
        [Header("Компонент кнопки")]
        [SerializeField] private Button _button;

        public void ChangeButtonActivity(bool state) =>
            _button.interactable = state;
    }
}