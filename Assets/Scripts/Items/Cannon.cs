using UnityEngine;

public class Cannon : Item
{
    [SerializeField] private CannonBall _cannonBall;

    public override void Use(GameObject player)
    {
        Mover mover = player.GetComponent<Mover>();

        if (mover != null)
        {
            CannonBall ball = Instantiate(_cannonBall, transform.position, Quaternion.identity);

            Vector3 direction = mover.LookDirection;

            ball.Shoot(direction);
        }

        base.Use(player);
    }
}
