using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    public GameObject bulletPrefab;
    public Transform bulletOrigin;
    public float timeBetweenShoots = 0.5f;
    public Text Vidajugador;

    public GameObject particleprefabdead;

    public AudioClip shootaudio;
    public AudioClip explosionaudio;

    private float timeOfLastShoot;


    private void Start()
    {
        currentHP = maxHP;
        Vidajugador.text = "Vida: " + currentHP;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time > timeOfLastShoot + timeBetweenShoots)
            shoot();
        }
    }

    public void Damage(float amount)
    {
        currentHP -= amount;
        Vidajugador.text = "Vida: " + currentHP;
        if (currentHP <= 0f)
        {
            Dead();
        }
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(bullet, 5f);
        timeOfLastShoot = Time.time;

        AudioSource.PlayClipAtPoint(shootaudio, transform.position, 0.7f);
    }

    private void Dead()
    {
        AudioSource.PlayClipAtPoint(explosionaudio, transform.position, 0.9f);

        Instantiate(particleprefabdead, transform.position, transform.rotation);
        FindObjectOfType<GameManager>().GameOver();
        Destroy(this.gameObject);
    }
}
