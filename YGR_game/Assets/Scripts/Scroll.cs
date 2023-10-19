using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = -0.5f; // Adjust scroll speed in the Inspector.

    public Renderer sky;
    public Renderer hill;
    private Material mat_s;
    private Material mat_h;
    public Move moveScript;

    void Start()
    {
        mat_s = sky.material;
        mat_h = hill.material;
    }

    void Update()
    {
        float offsetX = Time.time * scrollSpeedX * moveScript.speed;
        mat_s.SetTextureOffset("_MainTex", new Vector2(offsetX, 0f));
        mat_h.SetTextureOffset("_MainTex", new Vector2(offsetX * 2f, 0f));
    }
}
