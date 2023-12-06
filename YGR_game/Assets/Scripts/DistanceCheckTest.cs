using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class DistanceCheckTest : MonoBehaviour
{
    //in�s -- to access score distance ui
    public TMP_Text distScore;

    [System.Serializable]
    public class Spawning
    {
        public float distance;
        public string prefabName;
        public int position;
        //public GameObject prefab = GameObject.Find(objectName);
    }

    public float distance = 0;
    public int miles = 0;
    public float ygr_feet;
    public Move move;
    public Spawner spawner;
    public Spawning[] spawn;
    private bool[] spawnedFlags;

    // Start is called before the first frame update
    void Start()
    {
        ygr_feet = .2f;
        spawnedFlags = new bool[spawn.Length];
    }

    // Update is called once per frame
    void Update()
    {
        distance += ygr_feet * move.speed * Time.fixedDeltaTime;
        if(distance >= 100f)
        {miles += 1;
        distance = 0;
        spawner.buildingClone();
        spawner.fallClone(1);
        }
        spawnObjects(distance);
        //in�s -- update ui
        distScore.text = "Score: " + miles.ToString("F0");
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
