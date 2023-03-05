using MV;
using System.Collections.Generic;
using UnityEngine;

namespace Bonuses
{
    public class SpecialBonus : MonoBehaviour
    {
        [SerializeField] private int maxSpecials;
        [SerializeField] private float maxTime;
        [SerializeField] private float minTime;
        [SerializeField] private List<GameObject> specials;

        private int _collectedSpecials;
        private float _timeBetweenAppear;
        private float _nowTime;

        private void Start()
        {
            _timeBetweenAppear = Random.Range(minTime, maxTime);
        }

        private void Update()
        {
            if (_nowTime >= _timeBetweenAppear)
            {
                if (_collectedSpecials != maxSpecials)
                    specials[Random.Range(0, specials.Count)].SetActive(true);
                _nowTime = 0;
                enabled = false;
            }
            _nowTime += Time.deltaTime;
        }

        public void CollectSpecial()
        {
            Score.OnScoreChangeForSpecial(_collectedSpecials++);
            _timeBetweenAppear = Random.Range(minTime, maxTime);
            enabled = true;
        }
    }
}