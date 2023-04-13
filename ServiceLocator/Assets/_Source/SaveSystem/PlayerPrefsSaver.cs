using Core;
using UnityEngine;

namespace SaveSystem
{
    public class PlayerPrefsSaver : ISaver, IGameService
    {
        private const string SCORE_KEY = "Score";

        public void SaveScore(int score, string savePath = null)
        {
            PlayerPrefs.SetInt(SCORE_KEY, score);
            PlayerPrefs.Save();
        }
    }
}