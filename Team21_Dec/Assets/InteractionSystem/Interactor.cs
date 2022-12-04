using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _collider = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    public AudioSource pickupwoodSound;
    // Update is called once per frame
    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _collider, _interactableMask);

        if (_numFound > 0)
        {
            var _interactable = _collider[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame && _interactable.IsPickable() && !(_interactable.IsHouse()))
                {
                    _interactable.Pick(_interactionPoint);
                    _interactable.Interact(this);
                    pickupwoodSound.Play();
                }
                else if (Keyboard.current.eKey.wasPressedThisFrame && !(_interactable.IsPickable()) && !(_interactable.IsHouse()))
                {
                    _interactable.Interact(this);
                }
                else if (Keyboard.current.qKey.wasPressedThisFrame && _interactable.IsHouse())
                {
                    _interactable.Interact(this);
                }
            }
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
