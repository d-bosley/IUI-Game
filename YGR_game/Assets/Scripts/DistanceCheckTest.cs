using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DistanceCheckTest : MonoBehaviour
{

    [System.Serializable]
    public class Spawning
    {
        public float distance;
        public string prefabName;
        public int position;
        //public GameObject prefab = GameObject.Find(objectName);
    }

    public float distance = 0;
    public float miles = 0;
    float ygr_feet = .1f;
    public Move move;
    public Spawner spawner;
    public Spawning[] spawn;
    private bool[] spawnedFlags;

    // Start is called before the first frame update
    void Start()
    {
        spawnedFlags = new bool[spawn.Length];
    }

    // Update is called once per frame
    void Update()
    {
        distance += ygr_feet * move.speed * Time.fixedDeltaTime;
        //if (distance >= 1){miles += 1; distance = 0;}
        spawnObjects(distance);
    }

    void spawnObjects(float currentDistance)
    {
    for (int i = 0; i < spawn.Length; i++) 
    {
    if (currentDistance >= spawn[i].distance && !spawnedFlags[i]) 
    {
        spawner.spawnClone(spawn[i].prefabName, spawn[i].position);
        spawnedFlags[i] = true; // Set a flag to keep from endless spawning.
    }
    }
    }
}
