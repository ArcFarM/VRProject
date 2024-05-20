using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderWP_flag : MonoBehaviour
{
    //해당 웨이포인트에 다른 손님이 존재하는 지 판별하는 용도
    public bool flag = false;
    //손님이 온다면 연결된 메뉴판에 메뉴를 출력
    public GameObject menu;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Guest" && gameObject.tag == "Waypoint_Counter"){
            flag = true;
            menu.GetComponent<Show_Menu>().Display_Menu();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Guest"){
            flag = false;
        }
    }
}
