using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Falling : MonoBehaviour
{
    Vector3 thisPosition;
    float distance;
    GameObject myself;
    GameObject player;
    float velocity = 15f;
    int target;
    Move move;

    // Start is called before the first frame update
    void Start()
    {
        myself = gameObject;
        player = GameObject.Find("Player");
        if(player != null){move = player.GetComponent<Move>();}
        target = move.spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Vector3.zero);
        // Create value representing "velocity" that starts positive and becomes negative
        // Clamp the maximum and minimum values to ensure it won't "fall" too fast
        velocity = Mathf.Clamp(velocity - .415f, -30, 25);
        transform.Translate(Vector2.up * velocity * Time.deltaTime);
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(distance > 20){
        Destroy(myself, 1.0f);
    }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger zone has a collider with a specific tag (e.g., "Player").
        if (other.CompareTag("Player"))
        {
            // Access the health component of the object with the "Player" tag.
            Move move = other.GetComponent<Move>();
            HeartSystem health = other.GetComponent<HeartSystem>();
            Collider2D Collider = myself.GetComponent<Collider2D>();

            health.GainHearts();

            if(move != null)
            {
                Destroy(myself, 0f);
            }
        }
    }
}
