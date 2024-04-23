using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject tutorialUI;
    public bool showUI = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !showUI)
        {
            tutorialUI.SetActive(true);
            showUI = true;
        }
        else if (Input.anyKeyDown && showUI)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
