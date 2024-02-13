using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    //public GameObject[] hearts;
    [HideInInspector] public bool dead;
    public GameObject heartsParent;
    public GameObject gameOverUI;
    Image[] hearts;
    private int life;
    public AudioSource deadAudio;
    public GameManager manager;


    void Start()
    {
        //life is the amount of hearts we have
        //life = hearts.Length;
        hearts = heartsParent.GetComponentsInChildren<Image>();
        life = 3;
    }


    void Update()
    {
        if (dead == true)
        {
            //dead code
            //Debug.Log("we died");
        }
    }

    public void TakeDamage(int damage)
    {
        //take -1 if we have hearts
        if (life >= 1)
        {
            life -= damage;
            hearts[life].enabled = false;
            //heartImg.enabled = false;
            //Destroy(hearts[life].gameObject);
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
            hearts[life].enabled = true;
            //heartImg.enabled = true;
            life++;
        }
    }

    //show game over ui
    public void gameOver()
    {
        manager.SetHighScore();
        gameOverUI.SetActive(true);
        deadAudio.Play(); //play dead audio
    }
}
