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
        [Header("Номер уровня")]
        public int Number;

        [Header("Расстановка уровня")]
        public TypesOfFormations Formation;

        [Header("Карточки задания")]
        public List<AssetReferenceGameObject> Cards;
    }
}