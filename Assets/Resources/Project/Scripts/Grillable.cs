using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grillable : MonoBehaviour
{
    public GameObject cookedObject;
    public float collisionTime = 0f;

    private void Update()
    {
        if(collisionTime >= 5f)
        {
            gameObject.SetActive(false);
            Instantiate(cookedObject, transform.position, transform.rotation);
            collisionTime = 0f;
        }
    }
}
