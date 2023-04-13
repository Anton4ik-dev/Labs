using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class AdditionalScreenView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button scoreButton;
        [SerializeField] private Text scoreText;
        [SerializeField] private Image closePanel;
        [SerializeField] private float duration;

        public Image ClosePanel { get => closePanel; }
        public float Duration { get => duration; }

        public void Bind(Action changeState, Action changeScore)
        {
            closeButton.onClick.AddListener(() => changeState?.Invoke());
            scoreButton.onClick.AddListener(() => changeScore?.Invoke());
        }

        public void Expose()
        {
            closeButton.onClick.RemoveAllListeners();
            scoreButton.onClick.RemoveAllListeners();
        }

        public void UpdateScoreText(int score)
        {
            scoreText.text = $"{score}";
        }
    }
}