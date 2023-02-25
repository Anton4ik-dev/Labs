using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MV
{
    public class ScoreAndHealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private List<Image> health;
        [SerializeField] private List<GameObject> bonuses;
        [SerializeField] private Image losePanel;
        [SerializeField] private Image winPanel;

        public void UpdateScoreText(int score, int bonusesCollected)
        {
            scoreText.text = score.ToString();

            if(bonuses.Count == bonusesCollected)
            {
                Time.timeScale = 0;
                winPanel.gameObject.SetActive(true);
            }
        }

        public void UpdateHealthView(int healthRemain)
        {
            health[healthRemain].gameObject.SetActive(false);

            if (healthRemain == 0)
            {
                Time.timeScale = 0;
                losePanel.gameObject.SetActive(true);
            }
        }

        public void Restart()
        {
            Time.timeScale = 1;
            Health.OnGameEnd();
            Score.OnGameEnd();
            SceneManager.LoadScene(1);
        }

        public void MainMenu()
        {
            Time.timeScale = 1;
            Health.OnGameEnd();
            Score.OnGameEnd();
            SceneManager.LoadScene(0);
        }
    }
}