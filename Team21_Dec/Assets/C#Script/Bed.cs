using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool IsPickable()
    {
        return false;
    }

    public bool IsHouse()
    {
        return false;
    }

    public void Pick(Transform objectGrabPointTransform)
    {
        return;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Sleeping");
        return true;
    }


}
