using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Collection items;
    public DistanceCheckTest distance;
    public Move player;
    public TMP_Text hiScore;
    public TMP_Text gameOverScore;
    public int coinScore = 0;
    public int mileScore = 0;
    public int speedScore = 0;
    public int topScore;
    public int topMiles;
    public int topSpeed;
    public string highScore;


    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        //Setting the score
        //Score is the player's distance, number of coins, and their top speed
        coinScore = Mathf.Max(coinScore, items.coins);
        mileScore = distance.miles;
        speedScore = Mathf.RoundToInt(player.currentSpeed);
    }

        //SCORE DESCRIPTION
        //Grabs the highscore value of the game and saves it for later use, by creating a file that is stored on the local machine
        //What may work better is to save the score to the local browser session
        //No direct downloads and the file removes itself once the session closes
        //This also means the session should save even if they leave the site
        //It only closes once the browser session (the browser itself) has closed

    public void SetHighScore()
    {
        //Run this after the player has lost all of their hearts and the game has ended
        topScore = Mathf.Max(coinScore, PlayerPrefs.GetInt("HiScore", 0));
        topMiles = mileScore;
        topSpeed = speedScore;
        gameOverScore.text = $"SCORE: {topScore}";
        //topSpeed = Mathf.Max(speedScore, PlayerPrefs.GetInt("HiSpeed", 0);)
        PlayerPrefs.SetInt("HiScore", topScore);
        PlayerPrefs.SetInt("CnScore", coinScore);
        PlayerPrefs.SetInt("MiScore", topMiles);
        PlayerPrefs.SetInt("SpScore", topSpeed);
        //PlayerPrefs.SetInt("HiSpeed", topSpeed);
    }

    void UpdateHighScore()
    {
        highScore = $"Hi-Score: {PlayerPrefs.GetInt("HiScore", 0)}";
        hiScore.text = highScore;
        //highscore = $"Hi-Scores Miles: {PlayerPrefs.GetInt("HiScore", 0)} Speed: {PlayerPrefs.GetInt("HiSpeed", 0)}";

    }
}
