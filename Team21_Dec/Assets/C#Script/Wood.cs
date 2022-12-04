using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Transform OriginPoint;

    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    public string InteractionPrompt => _prompt;
    private bool pickingWood = false;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public bool IsHouse()
    {
        return false;
    }

    public bool IsPickable()
    {
        return true;
    }

    public void Pick(Transform objectGrabPointTransform)
    {
        if (!pickingWood)
        {
            pickingWood = true;
            this.objectGrabPointTransform = objectGrabPointTransform;
            objectRigidbody.useGravity = false;
        }
        else
        {
            pickingWood = false;
            this.objectGrabPointTransform = null;
            objectRigidbody.useGravity = true;
        }
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Pick Up Wood");
        return true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
            objectRigidbody.MovePosition(objectGrabPointTransform.position);
    }
}

