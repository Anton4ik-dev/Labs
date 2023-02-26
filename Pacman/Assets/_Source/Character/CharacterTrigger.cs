using Enemies;
using MV;
using UnityEngine;

public class CharacterTrigger : MonoBehaviour, IObserver
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask bonusLayer;
    [SerializeField] private LayerMask bigBonusLayer;
    [SerializeField] private BonusObservable bonusObservable;
    [SerializeField] private OnDamageAction onDamageAction;

    private int _enemyLayerNum;
    private int _bonusLayerNum;
    private int _bigBonusLayerNum;

    private int _damagedEnemies;
    private bool _isBonus;

    private void Start()
    {
        _enemyLayerNum = (int)Mathf.Log(enemyLayer.value, 2);
        _bonusLayerNum = (int)Mathf.Log(bonusLayer.value, 2);
        _bigBonusLayerNum = (int)Mathf.Log(bigBonusLayer.value, 2);
        bonusObservable.AddObserver(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _enemyLayerNum)
        {
            if (!_isBonus)
            {
                onDamageAction.OnDamage();
            }
            else
                collision.gameObject.GetComponent<AGhost>().TakeDamage(++_damagedEnemies);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _bonusLayerNum)
        {
            Score.OnScoreChange();
            Destroy(collision.gameObject);
        } 
        else if (collision.gameObject.layer == _bigBonusLayerNum)
        {
            bonusObservable.NotifyObservers(!_isBonus);
            Destroy(collision.gameObject);
        }
    }

    public void UpdateObserver(bool toActivate)
    {
        _isBonus = toActivate;

        if (toActivate == false)
            _damagedEnemies = 0;
    }
}