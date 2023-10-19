using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
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
/*         spawns = spawnParent.GetComponentsInChildren<Transform>();
        spawnOffsetA = new Vector3(10, 0, 0);
        spawnOffsetB = new Vector3(30, 0, 0); */
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger zone has a collider with a specific tag (e.g., "Player").
        if (other.CompareTag("Player"))
        {
            // Get the MoveScript and Slow the player down
            Move move = other.GetComponent<Move>();

            if(move != null)
            {
                move.speed = Mathf.Clamp(move.speed - .5f, 1, move.speed);
            }
        }
    }

    private void GetPositions()
    {
/*         if(moveScript.spawnPoint == 1)
        {
            if(moveScript.moving == true)
            {
            transform.position = spawns[3].position - spawnOffsetA;
            }
            transform.Translate(Vector2.right * (15f * moveScript.speed) * Time.deltaTime);
        }

        if(moveScript.spawnPoint == 3)
        {
            if(moveScript.moving == true)
            {
            transform.position = spawns[1].position + spawnOffsetB;
            }
            transform.Translate(Vector2.right * (-25f * moveScript.speed) * Time.deltaTime);
        }

        if(moveScript.spawnPoint == 2)
        {
            transform.position = spawns[1].position + spawnOffsetB;
        } */
    }
}