using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class MainScreenView : MonoBehaviour
    {
        [SerializeField] private Button openButton;
        [SerializeField] private Image openPanel;
        [SerializeField] private float duration;

        public Image OpenPanel { get => openPanel; }
        public float Duration { get => duration; }

        public void Bind(Action changeState, Tween tween)
        {
            openButton.onClick.AddListener(() => changeState?.Invoke());
            tween.Play().OnStart(() => openPanel.gameObject.SetActive(true));
        }

        public void Expose(Tween tween)
        {
            openButton.onClick.RemoveAllListeners();
            tween.Play().OnComplete(() => openPanel.gameObject.SetActive(false));
        }
    }
}