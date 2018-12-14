using UnityEngine;
using UnityEngine.UI;

public class ChestProperties: MonoBehaviour
{
    public GameObject Item;
    GameObject text;
    Text txt;
    
    void Start()
    {
        gameObject.SetActive(true);
        text = GameObject.Find("GUI/Report Panel/Text");
        txt = text.GetComponent<Text>();
        text.SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            text.SetActive(true);
            txt.text = "Press 'E' to open chest";
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            text.SetActive(true);
            txt.text = "Press 'E' to open chest";
            if (Input.GetKeyUp(KeyCode.E))
            {
                gameObject.SetActive(false);
                Instantiate(Item, gameObject.transform.position, gameObject.transform.rotation);
                txt.text = "Chest has been opened";
                text.SetActive(false);
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            text.SetActive(false);
        }
    }
}
