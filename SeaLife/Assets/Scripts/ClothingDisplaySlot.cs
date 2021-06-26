using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingDisplaySlot : MonoBehaviour
{
    public Wearable wearable;
    public Image icon;

    private ClothingGui clothingGui;
    private Button button;
    private GameObject border;

    void Start()
    {
        clothingGui = FindObjectOfType<ClothingGui>();

        border = transform.Find("BorderImg").gameObject;
        button = GetComponent<Button>();
        button.onClick.AddListener(BtnClicked);

        icon.sprite = wearable.icon;
    }   

    private void BtnClicked()
    {

        ClothingMgr.Instance.TryOn(wearable);
        border.SetActive(true);
    }
}
