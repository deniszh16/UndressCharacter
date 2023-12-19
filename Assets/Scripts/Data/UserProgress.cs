using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class UserProgress
    {
        public List<CharacterData> Characters;
        public int CurrentCharacter;
        
        public int Locale;

        public UserProgress()
        {
            Characters = new List<CharacterData>(capacity: 8);
            for (int i = 0; i < Characters.Capacity; i++)
                Characters.Add(new CharacterData());
            
            CurrentCharacter = 1;
            Characters[CurrentCharacter - 1].Activity = true;
            Characters[CurrentCharacter - 1].CharacterStage = 2;
            Characters[CurrentCharacter - 1].CharacterHearts = 18;
            Characters[CurrentCharacter].Activity = true;

            Locale = Application.systemLanguage == SystemLanguage.Russian ? 0 : 1;
        }

        public CharacterData GetCurrentCharacter() =>
            Characters[CurrentCharacter - 1];
    }
}