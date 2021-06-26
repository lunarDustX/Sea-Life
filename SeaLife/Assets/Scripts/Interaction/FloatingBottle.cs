using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBottle : MonoBehaviour, IInteractable
{
    public Item item;

    public string GetInteractTypeName()
    {
        return "PickUp(X)";
    }

    public void Interact()
    {
        bool itemPicked = Inventory.Instance.Add(item);
        if (itemPicked)
        {
            Destroy(this.gameObject);
        }
    }
}
