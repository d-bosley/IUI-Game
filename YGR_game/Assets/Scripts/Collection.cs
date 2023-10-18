using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collection : MonoBehaviour
{
    private int coins = 0;

    public TMP_Text CoinsTxt; //to have access to UI coin counter

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if object we entered has collectible tag...
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject); //destroy it
            coins += 1; //increment counter
            Debug.Log("coins: " + coins);
            CoinsTxt.text = "Coins: " + coins; //update UI
        }
    }
}
