using UnityEngine;
using UnityEngine.UI;

namespace Logic.UI.ListOfCharacters
{
    public class CharacterButton : MonoBehaviour
    {
        [Header("Номер персонажа")]
        [SerializeField] private int _number;

        public int Number => _number;
        
        [Header("Компоненты кнопки")]
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        [Header("Иконка кнопки")]
        [SerializeField] private Sprite _characterIcon;

        public void ChangeButtonActivity(bool state)
        {
            if (state)
            {
                _button.interactable = true;
                _image.sprite = _characterIcon;
            }
        }
    }
}