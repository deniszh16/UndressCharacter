using System;
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
                Debug.Log("_firstCard");
                _firstCard = selectedCard;
                return;
            }

            if (_secondCard == null && _firstCard.Equals(selectedCard) != true)
            {
                Debug.Log("_secondCard");
                _secondCard = selectedCard;
                CompareTwoCards();
            }
        }

        private void CompareTwoCards()
        {
            if (_firstCard.Type.Equals(_secondCard.Type))
            {
                _numberOfCards -= 2;
                _firstCard.HideCard();
                _secondCard.HideCard();
                ResetSelectedCards();
                CheckNumberOfCards();
            }
            else
            {
                _firstCard.CloseCard();
                _secondCard.CloseCard();
                ResetSelectedCards();
            }
        }

        private void ResetSelectedCards()
        {
            _firstCard = null;
            _secondCard = null;
        }

        private void CheckNumberOfCards()
        {
            if (_numberOfCards <= 0)
                AllCardsFound?.Invoke();
        }
    }
}