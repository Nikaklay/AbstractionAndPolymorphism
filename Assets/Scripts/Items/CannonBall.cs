using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bangPrefab;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _shootSpeed;

    private float _launchTime;
    private bool _isLaunched;

    private Vector3 _shootDirection;

    public void Shoot(Vector3 shootDirection)
    {
        _shootDirection = shootDirection;

        _isLaunched = true;
        _launchTime = Time.time;
    }

    private void Update()
    {
        if (_isLaunched)
        {
            transform.Translate(_shootSpeed * Time.deltaTime * _shootDirection, Space.World);
            
            if (_launchTime + _lifeTime < Time.time)
            {
                Instantiate(_bangPrefab, transform.position, Quaternion.identity);
                                
                Destroy(gameObject);
            }
        }
    }
}
