using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blinking : MonoBehaviour
{
    public GameObject textToBlink;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            if (textToBlink.activeInHierarchy)
            {
                textToBlink.SetActive(false);
            }
            else
            {
                textToBlink.SetActive(true);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
