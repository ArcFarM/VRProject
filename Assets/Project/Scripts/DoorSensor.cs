using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "Enter");
        if (other.tag == "Guest")
        {
            Door.GetComponent<DoorOpener>().open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "Exit");
        if(other.tag == "Guest")
        {
            Door.GetComponent<DoorOpener>().open = false;
        }
    }
}
