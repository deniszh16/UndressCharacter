using System.Collections.Generic;
using UnityEngine;

namespace Logic.Levels
{
    public class Arrangement : MonoBehaviour
    {
        [Header("Тип расстановки")]
        [SerializeField] private TypesOfFormations _type;

        public TypesOfFormations Type => _type;

        [Header("Позиции расстановки")]
        [SerializeField] private List<Transform> _positions;

        public Transform GetRandomPosition()
        {
            int number = Random.Range(0, _positions.Count);
            Transform position = _positions[number];
            _positions.Remove(position);
            return position;
        }
    }
}