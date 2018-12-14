using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            var Hit = collision.gameObject;
            var Health = Hit.GetComponent<PlayerHealth>();
            if (Health != null)
            {
                Health.TakeDamage(3);
            }
        }        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            var Hit = collision.gameObject;
            var Health = Hit.GetComponent<PlayerHealth>();
            if (Health != null)
            {
                Health.TakeDamage(1);
            }
        }
    }
}
