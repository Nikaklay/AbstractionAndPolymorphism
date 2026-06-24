using UnityEngine;

public class Cannon : Item
{
    [SerializeField] private CannonBall _cannonBall;

    public override void Use()
    {
        Mover player = GetComponentInParent<Mover>();

        if (player != null)
        {
            CannonBall ball = Instantiate(_cannonBall, transform.position, Quaternion.identity);

            Vector3 direction = player.LookDirection;

            ball.Shoot(direction);
        }

        base.Use();
    }
}
