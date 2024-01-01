using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class UserProgress
    {
        public int Level;
        public List<CharacterData> Characters;
        public int CurrentCharacter;

        public bool Sound;
        public int Locale;

        public UserProgress()
        {
            Level = 1;
            
            Characters = new List<CharacterData>(capacity: 8);
            for (int i = 0; i < Characters.Capacity; i++)
                Characters.Add(new CharacterData());
            
            CurrentCharacter = 1;
            Characters[CurrentCharacter - 1].Activity = true;

            Sound = true;
            Locale = Application.systemLanguage == SystemLanguage.Russian ? 0 : 1;
        }

        public CharacterData GetCurrentCharacter() =>
            Characters[CurrentCharacter - 1];

        public void UnlockNextCharacter()
        {
            if (CurrentCharacter < Characters.Count)
                Characters[CurrentCharacter].Activity = true;
        }
    }
}