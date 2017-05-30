using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectCamera : MonoBehaviour {

    GameObject targetItem;
    Vector3 targetPos;
    int nowItem = -1;
    Camera cam;


	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
        cam.depth = -0.2f;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            switch (Input.inputString)
            {
                case "1":
                    Debug.Log("1 pressed");
                    if (nowItem == 1)
                    {
                        nowItem = -1;
                        cam.depth = -0.2f;
                        break;
                    }
                    else
                    {
                        nowItem = 1;
                        targetItem = GameObject.Find("KeyforList");
                        targetPos = targetItem.transform.position;
                        cam.depth = 0.2f;
                        break;
                    }
                case "2":
                    Debug.Log("2 pressed");
                    break;
                default:
                    //Debug.Log("otherkeys");
                    break;
            }
        }

        if (nowItem != -1)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.RotateAround(targetPos, Vector3.up, Time.deltaTime * 150f);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.RotateAround(targetPos, Vector3.up, -Time.deltaTime * 150f);
            }
        }
    }
}
