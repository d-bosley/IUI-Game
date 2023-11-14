using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Move : MonoBehaviour
{
    //public TextMeshProUGUI debug;
    //public Collider2D box;
    public Tilemap tile;
    public GameObject spawnParent;
    public SpriteRenderer sprite;
    [HideInInspector] public float speed;
    [HideInInspector] public float currentSpeed;
    float timer = 2;
    float pauseTime = 2;
    float lockTime = 2;
    float countdown = 1;
    Transform[] spawns;
    [HideInInspector] public int spawnPoint;
    [HideInInspector] public bool moving = false;
    [HideInInspector] public bool playing = true;
    [HideInInspector] public bool stunned = false;
    [HideInInspector] public bool damaged = false;
    [HideInInspector] public bool locked = false;

    // Start is called before the first frame update
    private void Start()
    {
        spawns = spawnParent.GetComponentsInChildren<Transform>();
        // Initialize the character's position.
        transform.position = spawns[2].position;
        spawnPoint = 2;
        speed = 1;
        currentSpeed = speed;
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
    }

    private void PlayerSpeed()
    {
        if (!moving){
        timer -= countdown * Time.deltaTime;

        if (timer <= 0){speed += .025f * Time.deltaTime;}
        }

        else{
        timer = 2;
        }


        if (damaged)
        {
            locked = true;
            currentSpeed = currentSpeed;
            speed = 0;
            pauseTime -= countdown * Time.deltaTime;
            timer = 3;
            if(pauseTime <= 0)
            {
                speed = Mathf.Clamp(currentSpeed -.5f, 1, currentSpeed);
                pauseTime = 2;
                damaged = false;
                locked = false;
            }
        }
        else
        {
            currentSpeed = speed;
        }


        if (stunned)
        {
            locked = true;
            lockTime -= countdown * Time.deltaTime;
            if(lockTime <= 0)
            {
                lockTime = 2;
                stunned = false;
                locked = false;
            }
        }
    }

    private void Moving(int place)
    {
        if(!locked)
        {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = spawns[place].position;
        float distance = Vector3.Distance(currentPosition, targetPosition);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, .25f);
        moving = false;
        }
        //transform.Translate(direction * distance * Time.deltaTime);
        //transform.position = targetPosition;
        //debug.text = "Current: " + currentPosition.ToString() + "\nTarget: " +  targetPosition.ToString() + "\nDistance: " +  distance.ToString();
    }
}
