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

        public void Bind(Action changeState)
        {
            openButton.onClick.AddListener(() => changeState?.Invoke());
        }

        public void Expose()
        {
            openButton.onClick.RemoveAllListeners();
        }
    }
}