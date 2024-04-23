using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    Vector3 thisPosition;
    float distance;
    GameObject myself;
    GameObject player;
    Move move;
    public float value;
    //Sprite[] enemySprite = new Sprite[4];


    // Start is called before the first frame update
    void Start()
    {
        myself = gameObject;
        player = GameObject.Find("Player");
        if(player != null){move = player.GetComponent<Move>();}
        value = Random.Range(2f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Vector3.zero);
        transform.Translate(Vector2.right * -value * move.speed * Time.deltaTime);
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(distance > 25){
        Destroy(myself, 0f);
    }
    }
}
