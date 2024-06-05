using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_Switch : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ingredient")
        {
            if(!other.gameObject.GetComponent<Object_Hierarchy>().enabled){
                other.gameObject.GetComponent<Object_Hierarchy>().enabled = true;
            } else {
                other.gameObject.GetComponent<Object_Hierarchy>().enabled = false;
            }
        }
    }
}
