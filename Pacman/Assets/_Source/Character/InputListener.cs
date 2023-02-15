using UnityEngine;

namespace Character
{
    public class InputListener : MonoBehaviour
    {
        private CharacterMovement _characterMovement;

        private void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            if (moveX != 0)
                _characterMovement.MoveHorizontal(moveX);
            else if (moveY != 0)
                _characterMovement.MoveVertical(moveY);
        }

        public void Construct(CharacterMovement characterMovement)
        {
            _characterMovement = characterMovement;
        }
    }
}