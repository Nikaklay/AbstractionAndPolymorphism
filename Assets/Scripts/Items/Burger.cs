using UnityEngine;

public class Burger : Item
{
    private int Damage = 15;

    public override void Use(GameObject player)
    {
        Health health = player.GetComponent<Health>();

        if (health != null)
            health.TakeDamage(Damage);

        base.Use(player);
    }
}
