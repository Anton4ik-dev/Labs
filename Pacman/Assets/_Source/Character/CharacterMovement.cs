using UnityEngine;

namespace Character
{
    public class CharacterMovement
    {
        private Rigidbody2D _rb;
        private float _moveSpeed;

        public CharacterMovement(Rigidbody2D rb, float moveSpeed)
        {
            _rb = rb;
            _moveSpeed = moveSpeed;
        }

        public void MoveHorizontal(float x)
        {
            _rb.position += new Vector2(x * _moveSpeed * Time.deltaTime, 0);
        }

        public void MoveVertical(float y)
        {
            _rb.position += new Vector2(0, y * _moveSpeed * Time.deltaTime);
        }
    }
}