using UnityEngine;
using UnityEngine.Networking;

public class ChestSpawner : NetworkBehaviour
{
    public GameObject chestPrefab;
    public float RespawnTime;

    void Start()
    {
        if (!isServer)
        {
            return;
        }
        InvokeRepeating("RpcSpawn", RespawnTime, RespawnTime);
    }

    public override void OnStartServer()
    {
        for(int i = 0; i < 9; i++)
        {
            var spawnPosition = GameObject.Find("Chest Spawner/" + (i + 1)).GetComponent<Transform>().position;
            var spawnRotation = GameObject.Find("Chest Spawner/" + (i + 1)).GetComponent<Transform>().rotation;

            var chest = (GameObject)Instantiate(chestPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(chest);
        }
    }

    [ClientRpc]
    void RpcSpawn()
    {
        if (isServer)
        {
            GameObject.FindGameObjectWithTag("Chest").SetActive(true);
        }
    }
}
