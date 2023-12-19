using System;

namespace Data
{
    [Serializable]
    public class CharacterData
    {
        public bool Activity;
        public int CharacterHearts;
        public int CharacterStage;

        public CharacterData()
        {
            CharacterStage = 1;
        }
    }
}