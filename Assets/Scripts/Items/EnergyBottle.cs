using UnityEngine;

public class EnergyBottle : Item
{
    public override void Use(GameObject player)
    {
        Mover mover = player.GetComponent<Mover>();
        
        if (mover != null)
            mover.BoostSpeed();

        base.Use(player);
    }
}
