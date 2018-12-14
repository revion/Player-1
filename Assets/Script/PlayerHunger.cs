using UnityEngine;

public class PlayerHunger : MonoBehaviour
{
    public int HungerTime = 300;

    void Start()
    {
        InvokeRepeating("Hunger", HungerTime, HungerTime);
    }

    void Hunger()
    {
        var Health = GetComponent<PlayerHealth>();
        if (Health != null)
        {
            Health.TakeDamage(20);
        }
    }
}
