using DG.Tweening;
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

        public void Show(Action changeState, Action changeScore, Tween tween)
        {
            closeButton.onClick.AddListener(() => changeState?.Invoke());
            scoreButton.onClick.AddListener(() => changeScore?.Invoke());
            tween.Play().OnStart(() => closePanel.gameObject.SetActive(true));
        }

        public void Hide(Tween tween)
        {
            closeButton.onClick.RemoveAllListeners();
            scoreButton.onClick.RemoveAllListeners();
            tween.Play().OnComplete(() => closePanel.gameObject.SetActive(false));
        }

        public void UpdateScoreText(int score)
        {
            scoreText.text = $"{score}";
        }
    }
}