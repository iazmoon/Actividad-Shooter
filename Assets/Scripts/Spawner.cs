using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float timeBetweenSpawns = 1f;

    float bottomlimit;
    float toplimit;
    float leftlimit;
    float rightlimit;


    private void Start()
    {
        Vector3 bottomleft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        bottomlimit = bottomleft.y;
        leftlimit = bottomleft.x;

        Vector3 topright = Camera.main.ViewportToWorldPoint(Vector3.one);
        toplimit = topright.y;
        rightlimit = topright.x;


        InvokeRepeating("Spawn", 1f, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Spawn()
    {
        float x = Random.Range(leftlimit, rightlimit);
        Vector3 position = new Vector3(x, toplimit +  3f, 0f);

        int random = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[random], position, Quaternion.identity);


    }



}
