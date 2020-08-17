using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damageAmount = 10f;
    private Rigidbody2D rb;

    public GameObject particleshit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorito"))
        {
            MeteoritosMove meteoro = collision.gameObject.GetComponent<MeteoritosMove>();
            if (meteoro != null)
            {
                FindObjectOfType<Score>().AddPoints(10);

                meteoro.DestroyMet();
                GameObject particles = Instantiate(particleshit, transform.position, transform.rotation);
                Destroy(particles, 5f);
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Enimigos"))
        {
            EnimigosMove enimigos = collision.gameObject.GetComponent<EnimigosMove>();
            if (enimigos != null)
            {
                FindObjectOfType<Score>().AddPoints(20);
                enimigos.Damage(damageAmount);

                GameObject particles = Instantiate(particleshit, transform.position, transform.rotation);
                Destroy(particles, 5f);
                Destroy(this.gameObject);
            }
        }
    }

}
