using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Item", menuName = "Item/Basic Item")]
public class Item : ScriptableObject
{
    new public string name = "";
    public Sprite icon = null;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
