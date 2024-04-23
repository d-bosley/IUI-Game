using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TMP_Text hiScore;
    public TMP_Text hiCoins;
    public TMP_Text hiMiles;
    public TMP_Text hiSpeed;
    private string highScore;
    private string coinScore;
    private string highMiles;
    private string highSpeed;
    private int setScore;
    private int newScore;
    public GameObject marquee;
    public GameObject scoretext;

    // Start is called before the first frame update
    void Start()
    {
        SetHighScore();
        DisplayHighScore();
    }

    public void SetHighScore()
    {
        setScore = PlayerPrefs.GetInt("DisplayScore", 0);
        newScore = PlayerPrefs.GetInt("HiScore", 0);
        if(newScore > setScore)
        {
            marquee.active = true;
            scoretext.active = false;
            PlayerPrefs.SetInt("DisplayScore", newScore);
        }
    }

    void DisplayHighScore()
    {
        highScore = $"{PlayerPrefs.GetInt("DisplayScore", 0)} Coins";
        coinScore = $"{PlayerPrefs.GetInt("CnScore", 0)} Coins";
        highMiles = $"{PlayerPrefs.GetInt("MiScore", 0)} Miles";
        highSpeed = $"{PlayerPrefs.GetInt("SpScore", 0)} Mph";
        hiScore.text = highScore;
        hiCoins.text = coinScore;
        hiMiles.text = highMiles;
        hiSpeed.text = highSpeed;
        //highscore = $"Hi-Scores Miles: {PlayerPrefs.GetInt("HiScore", 0)} Speed: {PlayerPrefs.GetInt("HiSpeed", 0)}";
    }
}
