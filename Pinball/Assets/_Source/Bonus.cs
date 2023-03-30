using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int scoreChange;

    private Transform _spawnPos;
    private BonusPool _bonusPool;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Score.OnBonus(scoreChange);
            Destroy(gameObject);
            _bonusPool.ReturnSpawnPos(_spawnPos);
        }
    }

    public void AddSpawnPos(Transform spawnPos, BonusPool bonusPool)
    {
        _spawnPos = spawnPos;
        _bonusPool = bonusPool;
    }
}