using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWindow : MonoBehaviour {

    GameObject chat;
    bool onoff = true;

	// Use this for initialization
	void Start () {
        chat = GameObject.Find("ChatCanvas");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Debug.Log(chat.activeSelf);
            if (onoff == true)
            {
                chat.SetActive(false);
                onoff = false;
            }
            else
            {
                chat.SetActive(true);
                onoff = true;
            }
        }
	}
}
