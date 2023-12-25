using System;
using System.Collections.Generic;
using Logic.Levels;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Logic.StaticData
{
    [Serializable]
    public class LevelOptions
    {
        [Header("Расстановка уровня")]
        public TypesOfFormations Formation;

        [Header("Карточки задания")]
        public List<AssetReferenceGameObject> Cards;

        [Header("Секунды уровня")]
        public int Seconds;
    }
}