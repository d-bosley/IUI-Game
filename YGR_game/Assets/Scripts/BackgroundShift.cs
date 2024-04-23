using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShift : MonoBehaviour
{
    [System.Serializable]
    public class BuildingSprite
    {
        public Texture texture;
    }

    public Renderer rend;
    private Material mat;
    public BuildingSprite[] buildingSprite;
    public DistanceCheckTest Distance;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer> ();
        mat = rend.material;
        timer = 5;
        //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
        //m_Renderer.material.SetTexture("_MainTex", m_MainTexture);        
    }

    // Update is called once per frame
    void Update()
    {
        if(Distance.timer >= 50f)
        {
            ChangeSprite();
        }
        //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
        //m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
    }

    private void ChangeSprite()
    {
        int value = Random.Range(0, 9);
        Texture building = buildingSprite[value].texture;
        mat.mainTexture = building;
    }
}
