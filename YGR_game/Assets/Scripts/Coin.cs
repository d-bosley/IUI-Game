using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Coin : MonoBehaviour
{
/*  public GameObject player;
    public GameObject spawnParent;
    Transform[] spawns;
    int spawnPoint;
    Vector3 spawnOffsetA;
    Vector3 spawnOffsetB; */
    //public Move move;
    //public Spawner spawner;
    Vector3 thisPosition;
    float distance;
    GameObject myself;

    // Start is called before the first frame update
    void Start()
    {
        myself = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Vector3.zero);
        transform.Translate(Vector2.right * -30f * Time.deltaTime);
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(distance > 35){
        //Debug.Log("Too Far");
        Destroy(myself, 1.0f);
    }
    }
}