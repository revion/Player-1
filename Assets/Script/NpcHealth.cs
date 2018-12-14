using UnityEngine;
using UnityEngine.Networking;

public class NpcHealth : NetworkBehaviour
{
    public GameObject enemyModel;
    public const int MaxHitPoint = 5;
    [SyncVar]
    public int CurrentHP = MaxHitPoint;
    
    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        CurrentHP -= amount;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            Destroy(gameObject);
        }
    }
}
