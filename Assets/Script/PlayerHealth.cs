using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth: NetworkBehaviour
{
    public const int MaxHitPoint = 100;

    [SyncVar(hook = "UpdateHealth")]
    public int CurrentHP = MaxHitPoint;
    Text text;
    private NetworkStartPosition[] spawnPoints;

    void Start()
    {
        if (isLocalPlayer)
        {
            text = GameObject.Find("GUI/HP Panel/HP num").GetComponent<Text>();
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        CurrentHP -= amount;
        if(CurrentHP <= 0)
        {
            CurrentHP = 0;
            GameObject.Find("GUI/Report Panel/Text").SetActive(true);
            GameObject.Find("GUI/Report Panel/Text").GetComponent<Text>().text = "You are dead";
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        if (!isServer)
            return;

        CurrentHP += amount;
        GameObject.Find("GUI/Report Panel/Text").SetActive(true);
        GameObject.Find("GUI/Report Panel/Text").GetComponent<Text>().text = "Your health is restored";
        if (CurrentHP >= 100)
        {
            CurrentHP = 100;
        }
    }

    void UpdateHealth(int currentHealth)
    {
        text.text = string.Format("{0:000}", currentHealth);
    }
}
