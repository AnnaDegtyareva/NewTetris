
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";

        // Ваши сохранения
        public int money = 0;
        public int[] shop = new int[11];
        public bool IsMusic = true;
    }
}
