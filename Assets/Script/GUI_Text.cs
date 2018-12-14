using UnityEngine;
using UnityEngine.UI;

public class GUI_Text : MonoBehaviour
{
    Text text;

    public Text SetText
    {
        get
        {
            return text;
        }
        set
        {
            text = value;
        }
    }

	void Start () {
        text = GetComponent<Text>() as Text;
    }
}
