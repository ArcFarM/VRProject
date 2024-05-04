using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroyer OnTriggerEnter");
        //여기에 닿은 오브젝트가 Ingredient 태그를 가지고 있으면
        if (other.gameObject.tag.Contains("Ingredient"))
        {
            //오브젝트를 파괴
            Destroy(other.gameObject);
        }
    }
}
