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
    }

    public float distance = 0;
    public int miles = 0;
    public float timer = 0;
    public float ygr_feet;
    public Move move;
    public Spawner spawner;
    public Spawning[] spawn;
    private bool[] spawnedFlags;
    public HeartSystem hearts;
    public GameManager manager;

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
        manager.SetHighScore();
        hearts.gameOver();
        }

        timer += ygr_feet * move.speed * Time.fixedDeltaTime;
        if(timer >= 25f && distance < 100f)
        {
        spawner.fallClone(1);
        float newTime = (timer/25f) - 1f;
        timer = newTime;
        }

        spawnObjects(distance);
        float score = distance/100f;
        //in�s -- update ui
        distScore.text = "Miles: " + score.ToString("0.00");
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
