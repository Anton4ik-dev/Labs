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

        public void UpdateScoreText(int score)
        {
            scoreText.text = $"{score}";
        }

        public void UpdateHealthView(int healthRemain)
        {
            health[healthRemain].gameObject.SetActive(false);

            if (healthRemain == 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}