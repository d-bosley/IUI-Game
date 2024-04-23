using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collection : MonoBehaviour
{
    [HideInInspector] public int coins = 0;
    [HideInInspector] public int setCoins;

    public TMP_Text CoinsTxt; //to have access to UI coin counter
    public AudioSource coinCollectSound;
    public DistanceCheckTest distance;

    void Start()
    {
        setCoins = 0;
    }

    void Update()
    {
        SpawnPaddle();
    }
    
    private void SpawnPaddle()
    {
        if(coins >= setCoins + 30)
        {
            setCoins += 30;
            distance.SpawnPaddle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if object we entered has collectible tag...
        if (collision.CompareTag("Collectible"))
        {
            GameObject item = collision.GetComponent<GameObject>();
            Coin coin = collision.GetComponent<Coin>();
            coin.DestroyCoin(); //destroy it
            coins += coin.value; //increment counter
            coinCollectSound.Play(); //play sound
            //Debug.Log("coins: " + coins);
            CoinsTxt.text = "x " + coins; //update UI
        }
    }
}
