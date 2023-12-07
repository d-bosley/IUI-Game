using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class EnemySprite
    {
        public Sprite sprite;
    }

    Vector3 thisPosition;
    float distance;
    GameObject myself;
    GameObject player;
    Move move;
    SpriteRenderer rend;
    public EnemySprite[] enemySprite;
    //Sprite[] enemySprite = new Sprite[4];


    // Start is called before the first frame update
    void Start()
    {
        myself = gameObject;
        player = GameObject.Find("Player");
        rend = myself.GetComponent<SpriteRenderer>();
        if(player != null){move = player.GetComponent<Move>();}
        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Vector3.zero);
        transform.Translate(Vector2.right * -12f * move.speed * Time.deltaTime);
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
            // Access the health component of the object with the "Player" tag.
            Move move = other.GetComponent<Move>();
            HeartSystem health = other.GetComponent<HeartSystem>();
            Collider2D Collider = myself.GetComponent<Collider2D>();

            health.TakeDamage(1);

            if(move != null)
            {
                move.damaged = true;
                Collider.enabled = false;
                Destroy(myself, 2.0f);
            }
        }
    }

    private void ChangeSprite()
    {
        int value = Random.Range(0, 4);
        rend.sprite = enemySprite[value].sprite;
    }
}
