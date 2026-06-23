using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] int _speed;
    private CharacterController _characterController;



    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 direction = GetMovementDirection();
        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    private Vector3 GetMovementDirection()
    {
        float verticalDirection = Input.GetAxisRaw("Vertical");
        float horizontalDirection = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(horizontalDirection, 0, verticalDirection).normalized;

        return direction;
    }

}
