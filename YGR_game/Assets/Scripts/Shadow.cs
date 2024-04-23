using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    GameObject myself;
    GameObject falling;
    Falling fall;

    // Start is called before the first frame update
    void Start()
    {
        myself = gameObject;
        falling = GameObject.Find("Falling");
        if(falling != null){fall = falling.GetComponent<Falling>();}  
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }

        private void DestroyObject()
    {
        if(fall == null){
        Destroy(myself, 3f);
    }
    }
}
