using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Move moveScript;
    public GameObject player;
    public GameObject spawnParent;
    Transform[] spawns;
    int spawnPoint;
    Vector3 spawnOffsetA;
    Vector3 spawnOffsetB;

    // Start is called before the first frame update
    void Start()
    {
        spawns = spawnParent.GetComponentsInChildren<Transform>();
        spawnOffsetA = new Vector3(10, 0, 0);
        spawnOffsetB = new Vector3(30, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveScript.spawnPoint == 1)
        {
            if(moveScript.moving == true)
            {
            transform.position = spawns[3].position - spawnOffsetA;
            }
            transform.Translate(Vector2.right * 15f * Time.deltaTime);
        }

        if(moveScript.spawnPoint == 3)
        {
            if(moveScript.moving == true)
            {
            transform.position = spawns[1].position + spawnOffsetB;
            }
            transform.Translate(Vector2.right * -25f * Time.deltaTime);
        }

        if(moveScript.spawnPoint == 2)
        {
            transform.position = spawns[1].position + spawnOffsetB;
        }
    }
}
