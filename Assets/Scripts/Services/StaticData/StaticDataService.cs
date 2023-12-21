using System.Collections.Generic;
using System.Linq;
using Logic.StaticData;
using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string PathCharacters = "StaticData/Characters";
        private const string PathLevels = "StaticData/Levels/LevelsStaticData";
        
        private Dictionary<int, CharacterStaticData> _characters;
        private LevelsStaticData _levels;

        public void LoadCharacters()
        {
            _characters = Resources.LoadAll<CharacterStaticData>(PathCharacters)
                .ToDictionary(x => x.Number, x => x);
        }

        public CharacterStaticData GetCharacters(int number) =>
            _characters.TryGetValue(number, out CharacterStaticData staticData)
                ? staticData
                : null;

        public void LoadLevels() =>
            _levels = Resources.Load<LevelsStaticData>(PathLevels);

        public LevelsStaticData GetLevels() =>
            _levels;
    }
}