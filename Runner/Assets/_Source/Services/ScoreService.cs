using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Service
{
    public class ScoreService : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        private int _score;

        private void Awake()
        {
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            while(true)
            {
                scoreText.text = $"{_score++}";
                yield return new WaitForSeconds(1f);
            }
        }
    }
}