using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class Numpad : MonoBehaviour {

    GameObject Tex;
    string str = "";
    public GameObject selectedGameObject;
    //クリックでレイ（光線）とばす
    public Ray ray;
    public RaycastHit hit;
    public EventSystem eventsystem; //イベントシステム（いろんなことに使う）の定義

    // Use this for initialization
    void Start ()
    {
        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        Tex = GameObject.Find("DisplayText");
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*--------------
        画面クリック処理
        --------------*/
        if (Input.GetMouseButtonUp(0))
        { //左クリック
            if (eventsystem.currentSelectedGameObject == null)
            {// UI以外（3D）をさわった
                pushKey(); //3Dオブジェクトをクリックした時の処理
            }
        }
	}

    public void pushKey()
    {
        selectedGameObject = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 2.5f, 1 << 8))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.blue, 10f);
            selectedGameObject = hit.collider.gameObject;
            Debug.Log(selectedGameObject.name);

            if(selectedGameObject.name != "clear" && str.Length > 7)
            {
                return;
            }

            switch (selectedGameObject.name)
            {
                case "1":
                    str += "1";
                    break;
                case "2":
                    str += "2";
                    break;
                case "3":
                    str += "3";
                    break;
                case "4":
                    str += "4";
                    break;
                case "5":
                    str += "5";
                    break;
                case "6":
                    str += "6";
                    break;
                case "7":
                    str += "7";
                    break;
                case "8":
                    str += "8";
                    break;
                case "9":
                    str += "9";
                    break;
                case "0":
                    str += "0";
                    break;
                case "clear":
                    str = "";
                    break;

                default:
                    break;
            }
        }

        Tex.GetComponent<TextMesh>().text = string.Format(str);
    }

}
