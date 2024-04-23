using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControls : MonoBehaviour
{
        Vector2 touchPointA;
        Vector2 touchPointB;
        public GameObject arrows;
        Transform[] arrow;
        public int direction;
        public int place;
        Vector2 upArrow;
        Vector2 downArrow;
        public Camera cam;
        public Button btnUp;
        public Button btnDown;

    void Start()
    {
        //arrows.SetActive(false);
        //arrows.SetActive(true);
        arrows.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetInput();

        if(Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            touchPointA = Input.GetTouch(0).position;
            touchPointA = cam.ScreenToWorldPoint(new Vector3(touchPointA.x, touchPointA.y, 0));
            MyDebug(gameObject, "Message");
        }

        if(Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Ended)
        {
            touchPointB = Input.GetTouch(0).position;
            touchPointB = cam.ScreenToWorldPoint(new Vector3(touchPointB.x, touchPointB.y, 0));
            //Debug.Log("TOUCH: " + touchPointB + " UP: " + upArrow + " DOWN: " + downArrow);
        }

        //GetTouchInput();
        GetInputPoint();        
    }

    void GetTouchInput()
    {   
        if (touchPointB.y > touchPointA.y)
        {
            direction = -1;
        }

        if (touchPointB.y < touchPointA.y)
        {
            direction = 1;
        }

        if (Input.touchCount == 0)
        {
            direction = 0;
        }
    }

    void GetInputPoint()
    {
        if (Input.touchCount == 1)
        {
            if (Vector2.Distance(touchPointA, upArrow) < 8 && Vector2.Distance(touchPointB, downArrow) > 8)
            {
                direction = -1;
            }

            if (Vector2.Distance(touchPointA, downArrow) < 8 && Vector2.Distance(touchPointB, upArrow) > 8)
            {
                direction = 1;
            }
        }

        if (Input.touchCount == 0)
        {
            direction = 0;
        }
    }

    void SetInput()
    {
        if(Input.touchCount != 0)
        {
            arrows.SetActive(true);
        }

        if(Input.anyKeyDown)
        {
            arrows.SetActive(false);
        }

        arrow = arrows.GetComponentsInChildren<Transform>();
        downArrow = new Vector2(arrow[0].position.x, arrow[0].position.y);
        upArrow = new Vector2(arrow[1].position.x, arrow[1].position.y);
    }

    public static void MyDebug(GameObject obj, string txt)
    {
        Debug.Log(obj.GetInstanceID().ToString() + ": " + txt);
    }

    void TaskOnClick()
    {
		Debug.Log ("You have clicked the button!");
	}
}
