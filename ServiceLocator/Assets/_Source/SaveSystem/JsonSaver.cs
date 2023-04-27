using System.IO;
using UnityEngine;

namespace SaveSystem
{
    public class JsonSaver : ISaver
    {
        private const string SAVE_PATH = "/ScoreData.json";

        public void SaveScore(int score, string savePath = null)
        {
            string scoreToJson = JsonUtility.ToJson(new ScoreData(score));
            File.WriteAllText(Application.persistentDataPath + SAVE_PATH, scoreToJson);
            File.WriteAllText(Application.dataPath + SAVE_PATH, scoreToJson);
        }
    }
}