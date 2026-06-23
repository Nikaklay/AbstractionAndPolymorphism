using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private int SwingSpeed = 2;
    private int Smoothing = 10;

    private Vector3 _startPosition;

    private bool _isCollected;

    public void SetCollected() => _isCollected = true;

    public virtual void Use()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_isCollected == false)
            transform.position = _startPosition + Vector3.up * Mathf.Sin(SwingSpeed * Time.time) / Smoothing;
    }

    
}
