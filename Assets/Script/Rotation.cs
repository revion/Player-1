using UnityEngine;

public class Rotation : MonoBehaviour
{
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime);
        transform.LookAt(Vector3.zero);
	}
}
