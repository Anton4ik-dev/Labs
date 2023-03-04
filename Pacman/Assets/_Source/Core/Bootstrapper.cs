using Character;
using MV;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField] private InputListener inputListener;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Rigidbody2D characterRb;
        
        [Header("MV")]
        [SerializeField] private ScoreAndHealthView scoreAndHealthView;
        [SerializeField] private int scoreChangeAmount;
        [SerializeField] private int scoreChangeAmountForEnemy;
        [SerializeField] private int scoreChangeAmountForSpecial;
        [SerializeField] private int health;

        [Header("Other")]
        [SerializeField] private AudioSource bonusSound;

        private CharacterMovement _characterMovement;

        private void Awake()
        {
            _characterMovement = new CharacterMovement(characterRb, moveSpeed);
            inputListener.Construct(_characterMovement);

            new Score(scoreAndHealthView, bonusSound, scoreChangeAmount, scoreChangeAmountForEnemy, scoreChangeAmountForSpecial);
            new Health(scoreAndHealthView, health);
        }
    }
}