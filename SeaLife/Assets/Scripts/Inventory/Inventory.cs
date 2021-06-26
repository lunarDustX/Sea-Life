using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback; 

    public int space = 3;
    public List<Item> items = new List<Item>();

    public bool Add(Item _item)
    {
        if (items.Count >= space)
        {
            NoticeMgr.Instance.ShowMessage("Bag is full!");
            return false;
        }

        items.Add(_item);
        if (onItemChangedCallback != null)
            onItemChangedCallback();
        NoticeMgr.Instance.ShowMessage(_item.name + "+1");
        return true;
    }

    public void Remove(Item _item)
    {
        items.Remove(_item);
        if (onItemChangedCallback != null)
            onItemChangedCallback();
    }
}
