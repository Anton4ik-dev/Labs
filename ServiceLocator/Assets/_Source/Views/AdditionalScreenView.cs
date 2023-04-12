using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class AdditionalScreenView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Image closePanel;
        [SerializeField] private float duration;

        public Image ClosePanel { get => closePanel; }
        public float Duration { get => duration; }

        public void Bind(Action changeState)
        {
            closeButton.onClick.AddListener(() => changeState?.Invoke());
        }

        public void Expose()
        {
            closeButton.onClick.RemoveAllListeners();
        }
    }
}