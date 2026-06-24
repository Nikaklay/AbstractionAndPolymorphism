using UnityEngine;

public class EnergyBottle : Item
{
    public override void Use()
    {
        Mover player = GetComponentInParent<Mover>();
        
        if (player != null)
            player.BoostSpeed();

        base.Use();
    }
}
