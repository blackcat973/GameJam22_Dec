using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string InteractionPrompt { get; }

    public bool IsPickable();
    public bool IsHouse();
    public void Pick(Transform objectGrabPointTransform);
    public bool Interact(Interactor interactor);
}
