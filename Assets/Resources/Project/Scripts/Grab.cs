using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if(grabInteractable == null)
        {
            grabInteractable.selectedEnter.AddListener(OnGrabbed);
        }
        else
        {
            Debug.Log("GrabInteractable is null");
        }
    }

    void OnDestory()
    {
        if(grabInteractable != null)
        {
            grabInteractable.selectedEnter.RemoveListener(OnGrabbed);
        }
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        StartGame();
        gameObject.SetActive(false);
    }

    void StartGame()
    {
        Debug.Log("Game Started!");
    }
}
