using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;

    public string GetInteractTypeName()
    {
        return "TALK(X)";
    }

    public void Interact()
    {
        FindObjectOfType<PlayerInteraction>().interactable = null;
        //MainGui.Instance.HideInteractBtn();
        DialogueMgr.Instance.StartDialogue(dialogue, this.gameObject);
    }
}
