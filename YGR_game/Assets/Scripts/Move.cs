using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : MonoBehaviour
{
    public Tilemap tile;
    public GameObject spawnParent;
    [HideInInspector] public float speed;
    public Collider2D box;
    float timer = 2;
    float countdown = 1;
    Transform[] spawns;
    [HideInInspector] public int spawnPoint;
    [HideInInspector] public bool moving = false;
    [HideInInspector] public bool playing = true;

    // Start is called before the first frame update
    private void Start()
    {
        spawns = spawnParent.GetComponentsInChildren<Transform>();
        // Initialize the character's position.
        transform.position = spawns[2].position;
        spawnPoint = 2;
        speed = 1;
    }

    private void Update()
    {
        PlayerSpeed();

        int dir_Up = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        int dir_Down = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        spawnPoint = Mathf.Clamp(spawnPoint + dir_Down - dir_Up, 1, 3);
        Moving(spawnPoint);
        //Vector2 direction = Vector2.up * (dir_Up - dir_Down);
        //SnapToNearestPosition(direction)
        if (dir_Up != 0 || dir_Down != 0)
        {
        moving = true;
        }
    }

    private void TilePosition(Vector2 direction)
    {
        Vector3 currentPosition = transform.position;
        Vector3Int cellPosition = tile.WorldToCell(currentPosition);
        Vector3Int gridDirection = new Vector3Int(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y), 0);
        Vector3Int targetCellPosition = cellPosition + gridDirection;
        Vector3 targetPosition = tile.GetCellCenterWorld(targetCellPosition);
        float distance = Vector3.Distance(currentPosition, targetPosition);
        //transform.Translate(direction * distance * Time.deltaTime);
        //transform.position = targetPosition;
        //debug.text = "Current: " + currentPosition.ToString() + "\nTarget: " +  targetPosition.ToString() + "\nDistance: " +  distance.ToString();
    }

    private void PlayerSpeed()
    {
        if (!moving){
        timer -= countdown * Time.deltaTime;

        if (timer <= 0){speed += .0125f * Time.deltaTime;}
        }

        else{
        timer = 2;
        }
    }

    private void Moving(int place)
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = spawns[place].position;
        float distance = Vector3.Distance(currentPosition, targetPosition);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, .25f);
        moving = false;
        //transform.Translate(direction * distance * Time.deltaTime);
        //transform.position = targetPosition;
        //debug.text = "Current: " + currentPosition.ToString() + "\nTarget: " +  targetPosition.ToString() + "\nDistance: " +  distance.ToString();
    }
}
