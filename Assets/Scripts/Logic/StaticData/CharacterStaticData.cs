using UnityEngine;

namespace Logic.StaticData
{
    [CreateAssetMenu(fileName = "CharacterStaticData", menuName = "StaticData/Character Static Data")]
    public class CharacterStaticData : ScriptableObject
    {
        [Header("Номер персонажа")]
        public int Number;

        [Header("Количество сердечек")]
        public int[] NumberOfHearts;
    }
}