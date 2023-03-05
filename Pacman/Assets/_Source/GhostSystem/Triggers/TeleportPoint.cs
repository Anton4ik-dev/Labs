using UnityEngine;

namespace GhostSystem
{
    public class TeleportPoint : MonoBehaviour
    {
        [SerializeField] private Transform teleportPointPosition;
        public void Teleport(GameObject gameObjectToTeleport)
        {
            gameObjectToTeleport.transform.position = teleportPointPosition.position;
        }
    }
}