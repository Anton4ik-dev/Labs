namespace SaveSystem
{
    public interface ISaver
    {
        void SaveScore(int score, string savePath = null);
    }
}