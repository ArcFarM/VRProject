using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_Align : MonoBehaviour
{
    public GameObject plate;
    void Start(){
        transform.parent = plate.transform;
    }
    void OnTriggerEnter(Collider other)
    {
        //isKinematic이 켜져있는 '위에 놓인 재료'는 무시
        if (other.gameObject.tag == "Ingredient" && other.gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            //-0.15f : 접시가 현재 크기대로일떄 가운데에 위치한 것 처럼 보이게 하는 정도의 크기
            other.gameObject.transform.position = transform.position + new Vector3(-0.15f, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    
}
