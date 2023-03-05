using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GhostSystem
{
    public class RedGhostTriggerZone : MonoBehaviour
    {
        [SerializeField] private RedGhost redGhost;
        [SerializeField] protected LayerMask playerTriggerLayer;

        private int _playerTriggerNum;

        private void Start()
        {
            _playerTriggerNum = (int)Mathf.Log(playerTriggerLayer.value, 2);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _playerTriggerNum)
            {
                redGhost.ChangeMode();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _playerTriggerNum)
            {
                redGhost.ChangeMode();
            }
        }
    }
}