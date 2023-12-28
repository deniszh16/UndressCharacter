using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Logic.StaticData;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Logic.Levels
{
    public class ArrangementOfCards : MonoBehaviour
    {
        [Header("Варианты расстановок")]
        [SerializeField] private Arrangement[] _arrangement;

        private Arrangement _currentArrangement;
        private List<GameObject> _createdCards;

        private CardSelection _cardSelection;
        private CardSize _cardSize;

        public void Construct(CardSelection cardSelection, CardSize cardSize)
        {
            _createdCards = new List<GameObject>();
            _cardSelection = cardSelection;
            _cardSize = cardSize;
        }

        public void EnableSelectedArrangement(TypesOfFormations type)
        {
            foreach (var arrangement in _arrangement)
            {
                if (type != arrangement.Type) continue;
                _currentArrangement = arrangement;
                return;
            }
        }

        public void LoadAndInstantiatePrefabs(List<AssetReferenceGameObject> cards) =>
            _ = StartCoroutine(LoadAndInstantiatePrefabsCoroutine(cards));

        private IEnumerator LoadAndInstantiatePrefabsCoroutine(List<AssetReferenceGameObject> cards)
        {
            foreach (AssetReferenceGameObject card in cards)
            {
                Transform cardPosition = _currentArrangement.GetRandomPosition();
                card.InstantiateAsync(cardPosition.position, Quaternion.identity, _currentArrangement.transform)
                    .Completed += OnCardInstantiated;
            }
            
            yield return new WaitUntil(() => cards.All(operation => operation.IsDone));
        }

        private void OnCardInstantiated(AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _createdCards.Add(handle.Result);

                if (handle.Result.gameObject.TryGetComponent(out Card card))
                {
                    card.Construct(_cardSelection);
                    card.CustomizeSize(_cardSize);
                }
            }
        }

        private void OnDestroy()
        {
            foreach (GameObject card in _createdCards)
            {
                if (card != null)
                    Addressables.ReleaseInstance(card);
            }
        }
    }
}