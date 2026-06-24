using UnityEngine;

public class Health : MonoBehaviour
{
    private int CurrentHealth = 100;

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        Debug.Log($"Вы съели тухлый бургер, здоровье сократилось на {damage}хп");
        Debug.Log($"Текущее здоровье: {CurrentHealth}хп");
    }
}
