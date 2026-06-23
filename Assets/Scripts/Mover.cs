using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] float _speedMovement;
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
        Vector3 direction = GetMovementDirection();

        _characterController.Move(direction * _speedMovement * Time.deltaTime);

        Rotate(direction);
    }

    private void Rotate(Vector3 direction)
    {
        if (direction == Vector3.zero)
            transform.rotation = _currentRotation;

        Quaternion lookDirection = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, _speedRotation * Time.deltaTime);
        _currentRotation = transform.rotation;
    }

    private Vector3 GetMovementDirection()
    {
        float verticalDirection = Input.GetAxisRaw("Vertical");
        float horizontalDirection = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(horizontalDirection, 0, verticalDirection).normalized;

        return direction;
    }

}
