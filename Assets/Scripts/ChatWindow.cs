using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWindow : MonoBehaviour {

    GameObject chat;

	// Use this for initialization
	void Start () {
        chat = GameObject.Find("ChatCanvas");
        chat.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(chat.activeSelf);
            chat.SetActive(!chat.activeSelf);
        }
	}
}
