using DG.Tweening;
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
        [SerializeField] private List<Image> healthIcons;
        [SerializeField] private List<Image> specialIcons;
        [SerializeField] private List<GameObject> allBonuses;
        [SerializeField] private Image losePanel;
        [SerializeField] private Image winPanel;

        public void UpdateScoreText(int score, int bonusesCollected)
        {
            scoreText.text = score.ToString();

            if(allBonuses.Count == bonusesCollected)
            {
                Time.timeScale = 0;
                winPanel.gameObject.SetActive(true);
            }
        }

        public void UpdateHealthView(int healthRemain)
        {
            healthIcons[healthRemain].DOFade(0, 1.5f);

            if (healthRemain == 0)
            {
                Time.timeScale = 0;
                losePanel.gameObject.SetActive(true);
            }
        }

        public void UpdateSpecialIconsView(int collectedSpecials)
        {
            specialIcons[collectedSpecials].gameObject.SetActive(true);
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