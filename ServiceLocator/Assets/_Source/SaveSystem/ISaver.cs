using Core;

namespace SaveSystem
{
    public interface ISaver : IGameService
    {
        void SaveScore(int score, string savePath = null);
    }
}