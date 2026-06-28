using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _visualEffectPrefab;

    private Vector3 SwingPositionOffset = Vector3.up * 0.25f;
    private int SwingSpeed = 2;
    private int Smoothing = 10;

    private Vector3 _startPosition;

    private bool _isCollected;

    public void SetCollected() => _isCollected = true;

    public virtual void Use(GameObject player)
    {
        ParticleSystem visualEffect = Instantiate(_visualEffectPrefab, transform.position + Vector3.up, Quaternion.identity);

        visualEffect.Play();

        Destroy(gameObject);
    }

    protected virtual void Awake()
    {
        _startPosition = transform.position + SwingPositionOffset;
    }

    private void Update()
    {
        if (_isCollected == false)
            transform.position = _startPosition + Vector3.up * Mathf.Sin(SwingSpeed * Time.time) / Smoothing;
    }

    
}
