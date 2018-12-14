using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("Game");
        }
	}
}
