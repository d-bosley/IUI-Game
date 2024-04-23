using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector3 thisPosition;
    float distance;
    public int value;
    GameObject myself;
    GameObject player;
    Move move;

    // Start is called before the first frame update
    void Start()
    {
        myself = gameObject;
        player = GameObject.Find("Player");
        if(player != null){move = player.GetComponent<Move>();}
        
        //Red Coins are worth 1
        //Silver Coins are worth 5
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
        if(distance > 25){
        //Debug.Log("Too Far");
        Destroy(myself, 0f);
    }
    }

    public void DestroyCoin()
    {
        Destroy(myself, 0f);
    }
}