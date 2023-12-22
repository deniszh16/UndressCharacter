using UnityEngine;
using UnityEngine.EventSystems;

namespace Logic.Levels
{
    public class Card : MonoBehaviour, IPointerDownHandler
    {
        [Header("Тип карты")]
        [SerializeField] private TypesOfCards _type;

        public TypesOfCards Type => _type;

        [Header("Компоненты карты")]
        [SerializeField] private Animator _animator;
        [SerializeField] private BoxCollider2D _boxCollider;
        
        private static readonly int OpenCardAnimation = Animator.StringToHash("Open");
        private static readonly int HideCardAnimation = Animator.StringToHash("Hide");

        private CardSelection _cardSelection;

        public void Construct(CardSelection cardSelection) =>
            _cardSelection = cardSelection;

        public void OnPointerDown(PointerEventData eventData) =>
            OpenCard();

        private void OpenCard()
        {
            _cardSelection.WriteACard(this);
            _animator.SetBool(id: OpenCardAnimation, value: true);
        }

        public void CloseCard() =>
            _animator.SetBool(id: OpenCardAnimation, value: false);

        public void HideCard()
        {
            _boxCollider.enabled = false;
            _animator.SetTrigger(id: HideCardAnimation);
        }
    }
}