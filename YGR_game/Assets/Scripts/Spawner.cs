using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Move moveScript;
    public GameObject player;
    public GameObject spawnParent;
    Transform[] spawns;
    int spawnPoint;
    Vector3 spawnOffset;
    Vector3 fallOffset;
    public GameObject enemy;
    public GameObject coin;
    public GameObject paddle;
    public GameObject health;
    public GameObject falling;
    private Dictionary<string, GameObject> gameObjectDictionary;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        spawns = spawnParent.GetComponentsInChildren<Transform>();
        spawnOffset = new Vector3(30, 0, 0);
        fallOffset = new Vector3(0, 5, 0);

        // Setting up the Strings and their corresponding GameObjects
        gameObjectDictionary = new Dictionary<string, GameObject>
        {
            { "enemy", enemy },
            { "coin", coin },
            { "paddle", paddle },
            { "health", health },
            { "falling", falling }
        };
    }

    // Update is called once per frame
    void Update()
    {
       // ClockCycle();
    }

    void ClockCycle()
    {

    }

    void enemyClone(int spawn)
    {
        GameObject enemyClone = Instantiate(enemy, spawns[spawn].position + spawnOffset, Quaternion.identity);
    }

    void coinClone(int spawn)
    {
        GameObject coinClone = Instantiate(coin, spawns[spawn].position + spawnOffset, Quaternion.identity);
    }

    public void fallClone(int spawn)
    {
        GameObject fallClone = Instantiate(fall, spawns[spawn].position + fallOffset, Quaternion.identity);
    }

    public void spawnClone(string prefabName, int spawn)
    {
        gameObjectDictionary.TryGetValue(prefabName, out GameObject prefab);
        GameObject spawnClone = Instantiate(prefab, spawns[spawn].position + spawnOffset, Quaternion.identity);
    }

    //public void spawnClone(GameObject prefab, int spawn)
    //{
    //    GameObject spawnClone = Instantiate(prefab, spawns[spawn].position + spawnOffset, Quaternion.identity);
    //}
}
