using UnityEngine;

public class ItemCatcher : MonoBehaviour
{
    [SerializeField] private float _magnitOffset;

    private Item _currentItem;

    private bool _canTakeItem;

    private void Awake()
    {
        _canTakeItem = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (_currentItem != null)
            {
                _currentItem.Use();
                _canTakeItem = true;
            }
            else
                Debug.Log("Nothing to use");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item item = hit.gameObject.GetComponent<Item>();

        if (item != null && _canTakeItem)
        {
            _currentItem = item;

            item.SetCollected();

            item.transform.position = hit.point + hit.normal * _magnitOffset;
            item.transform.SetParent(transform);

            _canTakeItem = false;
        }
    }
}
