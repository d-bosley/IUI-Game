using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject gameOverUI;
    private int life;
    [HideInInspector] public bool dead;

    public AudioSource deadAudio; 


    void Start()
    {
        //life is the amount of hearts we have
        life = hearts.Length;
    }


    void Update()
    {
        if (dead == true)
        {
            //dead code
            Debug.Log("we died");
        }
    }

    public void TakeDamage(int damage)
    {
        //take -1 if we have hearts
        if (life >= 1)
        {
            life -= damage;
            Destroy(hearts[life].gameObject);
            //if we have no hearts
            if (life < 1) 
            {
                //we died
                dead = true;
                gameOver();
                
            }
        }
    }

    public void GainHearts()
    {
        if (life < 3)
        {
            life++;
        }
    }

    //show game over ui
    public void gameOver()
    {
        gameOverUI.SetActive(true);
        deadAudio.Play(); //play dead audio
    }
}
