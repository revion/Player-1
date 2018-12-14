using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject trapPrefab;
    public Transform trapSpawn;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CmdPutTrap();
        }
    }

    [Command]
    void CmdPutTrap()
    {
        var trap = (GameObject)Instantiate(trapPrefab, trapSpawn.position, trapSpawn.rotation);
        NetworkServer.Spawn(trap);
    }
}
