using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [HideInInspector] public IInteractable interactable;
    private KeyCode interactKey = KeyCode.X;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Interactable"))
        {
            interactable = _other.GetComponent<IInteractable>();
            MainGui.Instance.ShowInterectBtn(_other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.CompareTag("Interactable"))
        {
            interactable = null;
            MainGui.Instance.HideInteractBtn();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (interactable != null)
            {
                interactable.Interact();
                MainGui.Instance.HideInteractBtn();
            }
        }
    }
}
