using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // Adjust scroll speed in the Inspector.
    public Renderer bg_a;
    public Renderer bg_b;
    private Material mat_s;
    private Material mat_h;

    void Start()
    {
        mat_s = bg_a.material;
        mat_h = bg_b.material;
    }

    void Update()
    {
        float offsetX = Time.time * scrollSpeedX;
        mat_s.SetTextureOffset("_MainTex", new Vector2(offsetX, 0f));
        mat_h.SetTextureOffset("_MainTex", new Vector2(offsetX * 2f, 0f));
    }
}
