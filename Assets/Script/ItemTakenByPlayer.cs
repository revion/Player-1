using UnityEngine;
using UnityEngine.UI;

public class ItemTakenByPlayer : MonoBehaviour
{
    GameObject text;
    Text txt;

    void Start()
    {
        text = GameObject.Find("GUI/Report Panel/Text");
        txt = text.GetComponent<Text>();
    }

    void OnCollisionEnter(Collision col)
    {
        text.SetActive(true);
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            txt.text = "Prees E to take item";
        }
    }

    void OnCollisionStay(Collision col)
    {
        text.SetActive(true);
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                var Hit = col.gameObject;
                var Health = Hit.GetComponent<PlayerHealth>();
                if(Health != null)
                {
                    Health.Heal(30);
                }
                Destroy(gameObject);
                txt.text = "Your health is restored";
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
