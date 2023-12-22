using System;
using System.Collections;
using UnityEngine;

namespace Logic.Levels
{
    public class CardSelection : MonoBehaviour
    {
        private int _numberOfCards;

        public event Action AllCardsFound;
        
        private Card _firstCard;
        private Card _secondCard;

        public void SetNumberOfCards(int value) =>
            _numberOfCards = value;

        public void WriteACard(Card selectedCard)
        {
            if (_firstCard == null)
            {
                _firstCard = selectedCard;
                return;
            }

            _secondCard = selectedCard;
            CompareTwoCards();
        }

        private void CompareTwoCards()
        {
            if (_firstCard.Type.Equals(_secondCard.Type))
            {
                _numberOfCards -= 2;
                _firstCard.HideCard();
                _secondCard.HideCard();
                CheckNumberOfCards();
                return;
            }

            _ = StartCoroutine(ResetSelectedCards());
        }

        private IEnumerator ResetSelectedCards()
        {
            yield return new WaitForSeconds(0.5f);
            _firstCard.CloseCard();
            _firstCard = null;
            _secondCard.CloseCard();
            _secondCard = null;
        }

        private void CheckNumberOfCards()
        {
            if (_numberOfCards <= 0)
                AllCardsFound?.Invoke();
        }
    }
}