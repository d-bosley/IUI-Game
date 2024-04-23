using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll_Marquee : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // Adjust scroll speed in the Inspector.
    Vector2 baseScroll;

    public Image marquee;
    private Material marquee_mat;
    int offsetTex = 0;

    void Start()
    {
        marquee_mat = marquee.material;
    }

    void Update()
    {
        float scrollingX = scrollSpeedX * 1;
        Vector2 backgroundOffset = Vector2.right * scrollingX;

        //if(marquee_mat != null){Debug.Log("Okay");}
        marquee_mat.mainTextureOffset += backgroundOffset * .015f;
    }

}