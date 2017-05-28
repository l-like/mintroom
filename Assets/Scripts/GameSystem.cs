using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class GameSystem : MonoBehaviour
{

    public GameObject Player; //プレイヤの定義
    public EventSystem eventsystem; //イベントシステム（いろんなことに使う）の定義

    //クリックでレイ（光線）とばす
    public Ray ray;
    public Ray rayItem;
    public RaycastHit hit;
    public GameObject selectedGameObject;
    public GameObject door;

    private bool openDoor = false;


    // Use this for initialization
    void Start()
    {
        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        door = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {
        /*--------------
		画面クリック処理
		--------------*/
        if (Input.GetMouseButtonUp(0))
        { //左クリック
            if (eventsystem.currentSelectedGameObject == null)
            {// UI以外（3D）をさわった
                searchRoom(); //3Dオブジェクトをクリックした時の処理
            }
        }

        if (openDoor == true)
        {
            doorRotation();
        }
    }

    void doorRotation()
    {
        Debug.Log(Mathf.DeltaAngle(door.transform.eulerAngles.y, 180f));
        if (Mathf.DeltaAngle(door.transform.eulerAngles.y, 180f) > 0.1f)
        {
            door.transform.Rotate(new Vector3(0f, 0.3f, 0f));
        }
        else
        {
            openDoor = false;
        }

    }

    public void searchRoom()
    {
        selectedGameObject = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 2f, 1 << 8))
        {
            selectedGameObject = hit.collider.gameObject;
            switch (selectedGameObject.name)
            {
                case "Key":
                    Debug.Log("鍵取得");
                    GameObject.Find("Key").SetActive(false);
                    openDoor = true;
                    break;
            }
        }
    }

}
