using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // Adjust scroll speed in the Inspector.
    Vector2 baseScroll;

    public Renderer Far_B;
    public Renderer Far_C;
    public Renderer Mid_B;
    public Renderer Side_F;
    public Renderer Pole_F;
    private Material mat_BG;
    private Material mat_City;
    private Material mat_Build;
    private Material mat_Side;
    private Material mat_Pole;
    //public float streamSpeed_A;
    //public float streamSpeed_B;
    public Move moveScript;
    Renderer[] streams;
    public Texture[] buildings;
    int offsetTex = 0;
    Texture strip;
    public GameObject streamLayers;

    void Start()
    {
        streams = streamLayers.GetComponentsInChildren<Renderer>();
        mat_BG = Far_B.material;
        mat_City = Far_C.material;
        mat_Build = Mid_B.material;
        mat_Side = Side_F.material;
        mat_Pole = Pole_F.material;
        strip = buildings[0];
        mat_Build.mainTexture = strip;
        //baseScroll = Vector2.right * scrollSpeedX;
        //mat_s = sky.material;
        //mat_Pole = hill.material;
    }

    void Update()
    {
        // float offsetX = Time.time * scrollSpeedX * moveScript.speed;
        // mat_a.SetTextureOffset("_MainTex", new Vector2(offsetX, 0f));
        // mat_BG.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.125f, 0f));
        // mat_c.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.25f, 0f));
        // mat_Build.SetTextureOffset("_MainTex", new Vector2(offsetX * 1.5f, 0f));
        float speed = moveScript.speed;
        float scrolling = scrollSpeedX * speed;
        float scrollingX = scrollSpeedX * ((speed + 1) - speed);
        float offsetX = scrolling;
        Vector2 textureOffset = Vector2.right * offsetX;
        Vector2 backgroundOffset = Vector2.right * scrollingX;
        mat_BG.mainTextureOffset += textureOffset * .015f;
        mat_City.mainTextureOffset += textureOffset * .015f;
        mat_Build.mainTextureOffset += textureOffset * .005f;
        mat_Side.mainTextureOffset += textureOffset * 1.25f;
        mat_Pole.mainTextureOffset += textureOffset * 1.25f;

        for (int i = 0; i < streams.Length; i++)
        {
            Material layer = streams[i].material;
            float streamSpeed = (i + 1) * .0135f;
            layer.mainTextureOffset += textureOffset * streamSpeed * .95f;
        }

        if(mat_Build.mainTextureOffset.x >= offsetTex + 1)
        {
            offsetTex += 1;
            int buildingRand = Random.Range(0, 13);
            strip = buildings[buildingRand];
            mat_Build.mainTexture = strip;
        }
        //mat_e.mainTextureOffset += textureOffset * streamSpeed_A;
        //mat_f.mainTextureOffset += textureOffset * streamSpeed_B;
    }

}
