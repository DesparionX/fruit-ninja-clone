using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private AudioSource sound;
    public ParticleSystem ign;
    public ParticleSystem explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        else
        {
            FindObjectOfType<GameManager>().WithdrawSword();
            IgniteBomb();
        }
    }
    private void IgniteBomb()
    {
        sound = gameObject.GetComponent<AudioSource>();
        ign.Play();
        sound.Play();
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Invoke("Boom", 1.5f);
    }
    private void Boom()
    {
        explosion.Play();
        Invoke("GO", 1.2f);
    }
    private void GO()
    {
        FindObjectOfType<GameManager>().GameOver();
        
    }
    
}
