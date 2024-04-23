using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    string playName;
    int playScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetScoreUpdate(string name)
    {
        playName = name;
        playScore = PlayerPrefs.GetInt("HiScore", 0);
        HighScores.UploadScore(playName, playScore);
        Debug.Log("NAME: " + playName + " SCORE: " + playScore);
    }
}
