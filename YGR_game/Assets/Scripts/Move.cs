using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : MonoBehaviour
{
    public Tilemap tile;
    public GameObject spawnParent;
    Transform[] spawns;
    [HideInInspector] public int spawnPoint;
    [HideInInspector] public bool moving = false;

    // Start is called before the first frame update
    private void Start()
    {
        spawns = spawnParent.GetComponentsInChildren<Transform>();
        transform.position = spawns[2].position;
        spawnPoint = 2;
    }

    private void Update()
    {
        int dir_Up = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        int dir_Down = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        spawnPoint = Mathf.Clamp(spawnPoint + dir_Down - dir_Up, 1, 3);
        Moving(spawnPoint);
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
        transform.position = targetPosition;
    }

    private void Moving(int place)
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = spawns[place].position;
        float distance = Vector3.Distance(currentPosition, targetPosition);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, .25f);
        moving = false;
        //debug.text = "Current: " + currentPosition.ToString() + "\nTarget: " +  targetPosition.ToString() + "\nDistance: " +  distance.ToString();
    }
}
