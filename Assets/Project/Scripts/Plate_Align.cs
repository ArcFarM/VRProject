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
        if (other.gameObject.tag == "Ingredient")
        {
            Debug.Log("Test");
            //-0.15f : 접시가 현재 크기대로일떄 가운데에 위치한 것 처럼 보이게 하는 정도의 크기
            other.gameObject.transform.position = transform.position + new Vector3(-0.15f, 0, 0);
        }
    }
}
