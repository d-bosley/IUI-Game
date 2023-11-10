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
        transform.Translate(Vector2.up * -20f * Time.deltaTime);
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(distance > 10){
        //Debug.Log("Too Far");
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
            Collider2D Collider = myself.GetComponent<Collider2D>();

            if(move != null)
            {
                move.stunned = true;
                Collider.enabled = false;
                Destroy(myself, 2.0f);
            }
        }
    }
}
