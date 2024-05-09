using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderWP_Flag : MonoBehaviour
{
    //해당 웨이포인트에 다른 손님이 존재하는 지 판별하는 용도
    public bool flag = false;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Guest"){
            flag = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Guest"){
            flag = false;
        }
    }
}
