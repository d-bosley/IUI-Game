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
        // Impulse value that makes the object ascend before falling
        // Force value that makes the object fall once it's spawned
        transform.Translate(Vector2.up * -10f * Time.deltaTime);
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(distance > 10){
        Destroy(myself, 1.0f);
    }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger zone has a collider with a specific tag (e.g., "Player").
        if (other.CompareTag("Player") && target == move.spawnPoint)
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
