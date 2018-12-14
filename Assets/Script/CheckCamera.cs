using UnityEngine;
using UnityEngine.Networking;

public class CheckCamera : NetworkBehaviour
{
    public Camera cam;
	
	void Start () {
        if(isLocalPlayer)
        {
            cam.enabled = false;
        }
	}
}
