using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private Transform teleportTarget;
    [SerializeField] private GameObject thePlayer;

    public string InteractionPrompt => _prompt;

    public bool IsPickable()
    {
        return false;
    }

    public bool IsHouse()
    {
        return true;
    }

    public void Pick(Transform objectGrabPointTransform)
    {
        return;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Enter");
        thePlayer.transform.position = teleportTarget.transform.position;
        return true;
    }
}
