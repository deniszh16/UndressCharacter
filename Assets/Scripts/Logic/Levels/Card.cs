using System.Collections;
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

        private bool _availability;

        private CardSelection _cardSelection;

        public void Construct(CardSelection cardSelection)
        {
            _availability = true;
            _cardSelection = cardSelection;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_availability)
                OpenCard();
        }

        private void OpenCard()
        {
            _cardSelection.WriteACard(this);
            _animator.SetBool(id: OpenCardAnimation, value: true);
            _availability = false;
        }

        public void CloseCard() =>
            _ = StartCoroutine(CloseCardCoroutine());

        private IEnumerator CloseCardCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            _animator.SetBool(id: OpenCardAnimation, value: false);
            _availability = true;
        }

        public void HideCard() =>
            _ = StartCoroutine(HideCardCoroutine());

        private IEnumerator HideCardCoroutine()
        {
            _boxCollider.enabled = false;
            yield return new WaitForSeconds(0.5f);
            _animator.SetTrigger(id: HideCardAnimation);
        }
    }
}