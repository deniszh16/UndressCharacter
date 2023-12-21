using System.Collections.Generic;
using UnityEngine;

namespace Logic.StaticData
{
    [CreateAssetMenu(fileName = "LevelsStaticData", menuName = "StaticData/Levels Static Data")]
    public class LevelsStaticData : ScriptableObject
    {
        [Header("Список уровней")]
        public List<LevelOptions> Levels;
    }
}