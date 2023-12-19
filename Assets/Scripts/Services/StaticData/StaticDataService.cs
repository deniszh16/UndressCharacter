using System.Collections.Generic;
using System.Linq;
using Logic.StaticData;
using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string PathCharacters = "StaticData/Characters";
        
        private Dictionary<int, CharacterStaticData> _characters;


        public void LoadCharacters()
        {
            _characters = Resources.LoadAll<CharacterStaticData>(PathCharacters)
                .ToDictionary(x => x.Number, x => x);
        }

        public CharacterStaticData GetCharacters(int number) =>
            _characters.TryGetValue(number, out CharacterStaticData staticData)
                ? staticData
                : null;
    }
}