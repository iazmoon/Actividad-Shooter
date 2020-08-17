using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimigosMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject bulletprefab;
    public Transform bulletOrigin;

    public float timeBetweenShoots;
    private float timeOfLastShoot;

    public float maxHP = 100f;
    public float currentHP;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
        currentHP = maxHP;
    }

    private void Update()
    {
        if (Time.time > timeOfLastShoot + timeBetweenShoots)
            shoot();
        
    }
    public void Damage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(bullet, 5f);

        timeOfLastShoot = Time.time;
    }



}
