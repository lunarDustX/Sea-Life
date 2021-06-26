using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public List<string> loots;

    public string GetInteractTypeName()
    {
        return "OPEN(X)";
    }

    void IInteractable.Interact()
    {
        foreach (string itemName in loots)
        {
            NoticeMgr.Instance.ShowMessage(itemName + "+1");
        }

        // 清空宝箱
        loots.Clear();

        // 宝箱消失
        Destroy(this.gameObject);
    }
}
