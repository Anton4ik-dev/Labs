using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class RedGhost : MonoBehaviour, IObserver
    {
        [SerializeField] private float speed;
        [SerializeField] private LayerMask wallLayer;

        private int _wallLayerNum;

        private void Start()
        {
            _wallLayerNum = (int)Mathf.Log(wallLayer.value, 2);
        }

        private void Update()
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == _wallLayerNum)
            {
                transform.Rotate(new Vector3(0, 0, 90));
            }
        }

        public void UpdateObserver()
        {

        }
    }
}