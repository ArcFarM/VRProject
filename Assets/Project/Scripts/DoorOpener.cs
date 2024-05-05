using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Vector3 pivot;
    public float doorOpenAngle = -90.0f;
    public float doorCloseAngle = 0.0f;
    public float smooth = 2.0f;
    public bool open = false;

    private void Start()
    {
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        open = true;
        yield return new WaitForSeconds(3);
        open = false;
    }

    void Update()
    {
        if (open)
        {
            Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotationClose = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClose, smooth * Time.deltaTime);
        }
    }
}
