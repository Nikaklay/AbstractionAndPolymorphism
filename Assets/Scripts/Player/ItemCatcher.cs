using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Health))]
public class ItemCatcher : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private Item _currentItem;

    private bool _canTakeItem;

    private void Awake()
    {
        _canTakeItem = true;
    }

    private void Update()
    {
        if (_playerInput.IsUseKeyPressed())
        {
            if (_currentItem != null)
            {
                _currentItem.Use(gameObject);

                _currentItem = null;
                _canTakeItem = true;
            }
            else
                Debug.Log("Использовать нечего, персонаж без предмета");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.gameObject.GetComponent<Item>();

        if (item != null && _canTakeItem)
        {
            _currentItem = item;

            item.SetCollected();

            item.transform.SetParent(transform);
            item.transform.SetLocalPositionAndRotation(Vector3.forward, Quaternion.identity);
            
            _canTakeItem = false;
        }
    }
}
