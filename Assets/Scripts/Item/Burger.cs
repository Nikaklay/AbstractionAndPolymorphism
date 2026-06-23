using UnityEngine;

public class Burger : Item
{
    public override void Use()
    {
        Debug.Log("Destroy");

        base.Use();
    }
}
