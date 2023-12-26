using System.Collections;
using Logic.StaticData;
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
        
        private RectTransform _rectTransform;
        
        private static readonly int OpenCardAnimation = Animator.StringToHash("Open");
        private static readonly int HideCardAnimation = Animator.StringToHash("Hide");

        private static readonly Vector2 AverageSize = new(x: 180, y: 254);
        private static readonly Vector2 AverageBoxCollider = new(x: 170, y: 240);
        private static readonly Vector2 SmallSize = new(x: 151, y: 210);
        private static readonly Vector2 SmallBoxCollider = new(x: 145, y: 200);

        private bool _availability;

        private CardSelection _cardSelection;

        public void Construct(CardSelection cardSelection)
        {
            _availability = true;
            _cardSelection = cardSelection;
            _rectTransform = gameObject.GetComponent<RectTransform>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_availability)
                OpenCard();
        }

        public void CustomizeSize(CardSize cardSize)
        {
            if (cardSize == CardSize.Average)
            {
                _rectTransform.sizeDelta = AverageSize;
                _boxCollider.size = AverageBoxCollider;
            }

            if (cardSize == CardSize.Small)
            {
                _rectTransform.sizeDelta = SmallSize;
                _boxCollider.size = SmallBoxCollider;
            }
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