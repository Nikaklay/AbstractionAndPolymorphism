using UnityEngine;

namespace InterfacesHW
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector3 GetMovementDirection()
        {
            float verticalDirection = Input.GetAxisRaw("Vertical");
            float horizontalDirection = Input.GetAxisRaw("Horizontal");

            Vector3 direction = new Vector3(horizontalDirection, 0, verticalDirection).normalized;

            return direction;
        }
    }
}