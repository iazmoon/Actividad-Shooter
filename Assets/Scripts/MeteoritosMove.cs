using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritosMove : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    public float damageamount = 10f;

    public GameObject particleprefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player != null)
            {
                player.Damage(damageamount);
                DestroyMet();
            }
        }

    }

    public void DestroyMet()
    {
        GameObject particles = Instantiate(particleprefab, transform.position, transform.rotation);
        Destroy(particles, 5f);
        Destroy(this.gameObject);
    }

}
