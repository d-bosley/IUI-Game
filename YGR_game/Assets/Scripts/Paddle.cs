using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger zone has a collider with a specific tag (e.g., "Player").
        if (other.CompareTag("Player"))
        {
            // Get the player Scripts
            float invincible = 10;
            Move move = other.GetComponent<Move>();

            if(move != null)
            {
                invincible -= Time.time;
                move.box.enabled = invincible > 0 ? false : true;
            }
        }
    }
}
