using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // Adjust scroll speed in the Inspector.
    Vector2 baseScroll;

    public Renderer bg_a;
    public Renderer bg_b;
    public Renderer bg_c;
    public Renderer bg_d;
    private Material mat_a;
    private Material mat_b;
    private Material mat_c;
    private Material mat_d;
    public Move moveScript;

    void Start()
    {
        mat_a = bg_a.material;
        mat_b = bg_b.material;
        mat_c = bg_c.material;
        mat_d = bg_d.material;
        //baseScroll = Vector2.right * scrollSpeedX;
        //mat_s = sky.material;
        //mat_h = hill.material;
    }

    void Update()
    {
        // float offsetX = Time.time * scrollSpeedX * moveScript.speed;
        // mat_a.SetTextureOffset("_MainTex", new Vector2(offsetX, 0f));
        // mat_b.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.125f, 0f));
        // mat_c.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.25f, 0f));
        // mat_d.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.5f, 0f));
        float speed = moveScript.speed;
        float scrolling = scrollSpeedX * speed;
        float offsetX = scrolling;
        Vector2 textureOffset = Vector2.right * offsetX;
        mat_a.mainTextureOffset += textureOffset;
        mat_b.mainTextureOffset += textureOffset * 1.125f;
        mat_c.mainTextureOffset += textureOffset * 5f;
        mat_d.mainTextureOffset += textureOffset * 5.95f;
    }

}
