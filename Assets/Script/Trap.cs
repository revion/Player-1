using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Trap : MonoBehaviour
{
    public AudioClip impactSFX;
    //public Transform impactFX;
    AudioSource FX;

    void Awake()
    {
        //Instantiate(impactFX, transform.position, transform.rotation);
        FX = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            var Hit = collision.gameObject;
            var Health = Hit.GetComponent<PlayerHealth>();
            if (Health != null)
            {
                Health.TakeDamage(10);
            }
            AudioSource.PlayClipAtPoint(impactSFX,transform.position);
            Destroy(gameObject);
        }
    }
}
