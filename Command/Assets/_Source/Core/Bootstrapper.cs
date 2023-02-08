using UnityEngine;
using Command;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform character;

        private void Awake()
        {
            inputListener.Construct(mainCamera, new CommandInvoker(prefab, character));
        }
    }
}