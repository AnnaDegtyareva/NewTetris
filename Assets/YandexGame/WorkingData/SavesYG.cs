
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";

        // Ваши сохранения
        public int money = 1;
        public int[] shop = new int[11];
    }
}
