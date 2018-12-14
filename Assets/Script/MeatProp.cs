using UnityEngine;

public class MeatProp : MonoBehaviour
{
    void Update()
    {
        var Health = GetComponent<PlayerHealth>();
        if(Health != null)
        {
            Health.Heal(30);
        }
    }
}
