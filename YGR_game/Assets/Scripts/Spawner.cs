using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float clockA = 5;
    float clockB = 8;
    float clockC = 12;
    float clockD = 7;
    public Move moveScript;
    public GameObject player;
    public GameObject spawnParent;
    Transform[] spawns;
    int spawnPoint;
    Vector3 spawnOffset;
    public GameObject enemy;
    public GameObject coin;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        spawns = spawnParent.GetComponentsInChildren<Transform>();
        spawnOffset = new Vector3(30, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ClockCycle();
    }

    void ClockCycle()
    {
    
    clockA -= 1 * Time.deltaTime;
	if (clockA <= 0){
    enemyClone(1);
    clockA = 5;}

    clockB -= 1 * Time.deltaTime;
	if (clockB <= 0){
    enemyClone(2);
    clockB = 8;}

    clockC -= 1 * Time.deltaTime;
	if (clockC <= 0){
    enemyClone(3);
    clockC = 12;}

    clockD -= 1 * Time.deltaTime;
	if (clockD <= 0){
    coinClone(3);
    clockD = 7;}
    }

    void enemyClone(int spawn)
    {
        GameObject enemyClone = Instantiate(enemy, spawns[spawn].position + spawnOffset, Quaternion.identity);
    }

    void coinClone(int spawn)
    {
        GameObject coinClone = Instantiate(coin, spawns[spawn].position + spawnOffset, Quaternion.identity);
    }
}
