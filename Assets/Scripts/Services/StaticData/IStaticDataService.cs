using Logic.StaticData;

namespace Services.StaticData
{
    public interface IStaticDataService
    {
        public void LoadCharacters();
        public CharacterStaticData GetCharacters(int number);
        public void LoadLevels();
        public LevelsStaticData GetLevels();
    }
}