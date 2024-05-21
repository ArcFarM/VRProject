using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeightAdjust : MonoBehaviour
{
    public GameObject xrOrigin;
    public float fixedHeight = 1.5f;
    void Update()
    {
        if(xrOrigin != null)
        {
            Vector3 position = transform.position;
            position.y = fixedHeight;
            transform.position = position;
        }
    }
}
