using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TimerUI : NetworkBehaviour
{
	[SyncVar(hook ="GameTime")]
    public float Timer;

    Text text;

    void Start()
    {
        text = GetComponent<Text>() as Text;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
    }
    
    void GameTime(float gametime)
    {
        var sec = (int)gametime % 60;
        var min = (int)gametime / 60;
        text.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
