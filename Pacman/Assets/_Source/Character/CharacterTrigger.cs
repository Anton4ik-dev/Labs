using MV;
using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask bonusLayer;

    private int _enemyLayerNum;
    private int _bonusLayerNum;

    private void Start()
    {
        _enemyLayerNum = (int)Mathf.Log(enemyLayer.value, 2);
        _bonusLayerNum = (int)Mathf.Log(bonusLayer.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _enemyLayerNum)
        {
            Health.OnHealthChange();
        }
        else if (collision.gameObject.layer == _bonusLayerNum)
        {
            Score.OnScoreChange();
            Destroy(collision.gameObject);
        }
    }
}