using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 thisPosition;
    float distance;
    GameObject myself;
    GameObject player;
    Move move;

    // Start is called before the first frame update
    void Start()
    {
        myself = gameObject;
        player = GameObject.Find("Player");
        if(player != null){move = player.GetComponent<Move>();}
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Vector3.zero);
        transform.Translate(Vector2.right * -30f * move.speed  * Time.deltaTime);
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
            // Get the player Scripts
            Move move = other.GetComponent<Move>();
            HeartSystem hearts = other.GetComponent<HeartSystem>();

            if(move != null)
            {
                move.speed = Mathf.Clamp(move.speed - .5f, 1, move.speed);
            }

            if(hearts != null)
            {
                hearts.TakeDamage(1);
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