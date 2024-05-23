using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Ing_Enum;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Pouring_Sauce : MonoBehaviour
{
    public GameObject Poured_Bread;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bun"))
        {
            Instantiate(Poured_Bread, other.transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);
        }
    }
}
