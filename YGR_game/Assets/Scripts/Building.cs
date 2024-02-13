using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [System.Serializable]
    public class BuildingSprite
    {
        public Sprite sprite;
    }

    Vector3 thisPosition;
    float distance;
    GameObject myself;
    GameObject player;
    Move move;
    SpriteRenderer rend;
    public BuildingSprite[] buildingSprite;

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
        transform.Translate(Vector2.right * -8f * move.speed * Time.deltaTime);
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(distance > 80){
        //Debug.Log("Too Far");
        Destroy(myself, 1.0f);
    }
    }

    private void ChangeSprite()
    {
        int value = Random.Range(0, 11);
        rend.sprite = buildingSprite[value].sprite;
    }
}