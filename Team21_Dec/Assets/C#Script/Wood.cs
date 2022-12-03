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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Fire")
        {
            Score.score += 1;
            Debug.Log("Put the firewood in the fire.");
            Destroy(gameObject);
        }
    }
}

