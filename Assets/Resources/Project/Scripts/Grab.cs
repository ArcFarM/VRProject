using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grab : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    void Start()
    {
        if(grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
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
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
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
