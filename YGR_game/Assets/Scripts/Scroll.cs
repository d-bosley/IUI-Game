using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = -0.5f; // Adjust scroll speed in the Inspector.

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
    }

    void Update()
    {
        float offsetX = Time.time * scrollSpeedX * moveScript.speed;
        mat_a.SetTextureOffset("_MainTex", new Vector2(offsetX, 0f));
        mat_b.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.125f, 0f));
        mat_c.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.25f, 0f));
        mat_d.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.5f, 0f));
    }
}
