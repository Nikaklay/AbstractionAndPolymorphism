using UnityEngine;

namespace InterfacesHW
{
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        [SerializeField] private float _speedMovement;
        [SerializeField] float _speedRotation;

        private CharacterController _characterController;

        private Quaternion _currentRotation;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            _currentRotation = Quaternion.identity;
        }

        private void Update()
        {
            Vector3 direction = _playerInput.GetMovementDirection();

            _characterController.Move(_speedMovement * Time.deltaTime * direction);

            Rotate(direction);
        }

        private void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero)
                transform.rotation = _currentRotation;
            else
            {
                Quaternion lookDirection = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, _speedRotation * Time.deltaTime);
                _currentRotation = transform.rotation;
            }
        }
    }
}
