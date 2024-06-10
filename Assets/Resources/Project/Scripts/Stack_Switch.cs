using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_Switch : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ingredient"
         && other.transform.childCount <= other.gameObject.GetComponent<Ing_Code>().init_child)
        {
            Object_Hierarchy oh = other.gameObject.GetComponent<Object_Hierarchy>();
            if(oh.enabled == false){
                oh.enabled = true;
                oh.flag_switch(1);
            } else {
                oh.enabled = false;
                oh.flag_switch(0);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ingredient" && 
        other.transform.childCount <= other.gameObject.GetComponent<Ing_Code>().init_child)
        {
            other.gameObject.GetComponent<Object_Hierarchy>().enabled = true;
            other.gameObject.GetComponent<Object_Hierarchy>().flag_switch(1);
        }
    }
}
