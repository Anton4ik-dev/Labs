using System.Collections.Generic;
using UnityEngine;

public class BonusPool : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoses;
    [SerializeField] private List<Bonus> bonusesPrefs;
    [SerializeField] private float timeToSpawn;

    private float nowTime;

    private void Update()
    {
        if(nowTime >= timeToSpawn)
        {
            nowTime = 0;
            if(spawnPoses.Count != 0)
            {
                int rnd = Random.Range(0, spawnPoses.Count);
                Bonus bonus = Instantiate(bonusesPrefs[Random.Range(0, bonusesPrefs.Count)], spawnPoses[rnd]);
                bonus.AddSpawnPos(spawnPoses[rnd], this);
                spawnPoses.RemoveAt(rnd);
            }
        }
        nowTime += Time.deltaTime;
    }

    public void ReturnSpawnPos(Transform spawnPos)
    {
        spawnPoses.Add(spawnPos);
    }
}