using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class InputListener : MonoBehaviour
    {
        private CharacterFunctions _characterFunctions;

        private void Update()
        {
            _characterFunctions.Run();

            if (Input.GetKeyDown(KeyCode.W))
                _characterFunctions.Jump();
            else if (Input.GetKeyDown(KeyCode.S))
                _characterFunctions.Slide();
            else if (Input.GetKeyUp(KeyCode.S))
                _characterFunctions.Jump();
            else if (Input.GetKeyUp(KeyCode.W))
                _characterFunctions.Slide();
            else if (Input.GetKeyDown(KeyCode.A))
                _characterFunctions.Left();
            else if (Input.GetKeyDown(KeyCode.D))
                _characterFunctions.Right();

            if (Input.GetMouseButtonDown(0))
                _characterFunctions.Shoot();
        }

        [Inject]
        public void Construct(CharacterFunctions characterFunctions)
        {
            _characterFunctions = characterFunctions;
        }
    }
}