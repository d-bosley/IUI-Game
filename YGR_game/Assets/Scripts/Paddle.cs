using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
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
        transform.Translate(Vector2.right * -12f * move.speed  * Time.deltaTime);
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(distance > 35){
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
            Collider2D Collider = myself.GetComponent<Collider2D>();

            if(move != null)
            {
                move.invincible = true;
                Collider.enabled = false;
                Destroy(myself, 0f);
            }
        }
    }
}
