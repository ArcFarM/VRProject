using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting_Foods : MonoBehaviour
{
    public GameObject slicedChesse;
    public GameObject slicedFish;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("CheeseBig"))
        {
            collision.gameObject.SetActive(false);
            GameObject cheese = Instantiate(slicedChesse, collision.transform.position, Quaternion.identity);
        }

        if(collision.gameObject.name == "Anchovy")
        {
            collision.gameObject.SetActive(false);
            GameObject fish = Instantiate(slicedFish, collision.transform.position, Quaternion.identity);
        }
    }
}