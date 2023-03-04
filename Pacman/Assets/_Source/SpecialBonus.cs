using MV;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBonus : MonoBehaviour
{
    [SerializeField] private int maxSpecials;
    [SerializeField] private float maxTime;
    [SerializeField] private float minTime;
    [SerializeField] private List<GameObject> specials;

    private int collectedSpecials;
    private float timeBetweenAppear;
    private float nowTime;

    private void Start()
    {
        timeBetweenAppear = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        if (nowTime >= timeBetweenAppear)
        {
            if(collectedSpecials != maxSpecials)
                specials[Random.Range(0, specials.Count)].SetActive(true);
            nowTime = 0;
            enabled = false;
        }
        nowTime += Time.deltaTime;
    }

    public void CollectSpecial()
    {
        Score.OnScoreChangeForSpecial(collectedSpecials++);
        timeBetweenAppear = Random.Range(minTime, maxTime);
        enabled = true;
    }
}