using UnityEngine;

public class Burger : Item
{
    private int Damage = 15;

    public override void Use()
    {
        Health health = GetComponentInParent<Health>();

        if (health != null)
            health.TakeDamage(Damage);

        base.Use();
    }
}
