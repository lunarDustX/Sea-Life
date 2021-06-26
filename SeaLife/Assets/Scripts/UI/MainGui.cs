using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGui : MonoBehaviour
{
    #region Singleton
    public static MainGui Instance;
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

    public GameObject MapGUI;
    public GameObject ClothingGUI;
    public Button mapBtn;
    public Button bagBtn;
    public Button dressBtn;
    public GameObject interactBtn;

    private GameObject objToInteract;
    private GameObject bag;

    void Start()
    {
        bag = transform.Find("Bag").gameObject;
        BindAction();
    }

    void BindAction()
    {
        mapBtn.onClick.AddListener(MapBtnClicked);
        bagBtn.onClick.AddListener(BagBtnClicked);
        dressBtn.onClick.AddListener(DressBtnClicked);
    }

    private void DressBtnClicked()
    {
        ClothingGUI.SetActive(true);
    }

    private void BagBtnClicked()
    {
        bag.SetActive(!bag.activeSelf);
    }

    private void MapBtnClicked()
    {
        MapGUI.SetActive(true);
    }

    private void Update()
    {
        if (interactBtn.activeSelf)
        {
            interactBtn.transform.position = Camera.main.WorldToScreenPoint(objToInteract.transform.position + new Vector3(0, 1, 0));
        }
    }

    // 显示交互按钮
    public void ShowInterectBtn(GameObject _obj)
    {
        objToInteract = _obj;

        interactBtn.GetComponentInChildren<Text>().text = _obj.GetComponent<IInteractable>().GetInteractTypeName();
        interactBtn.SetActive(true);
    }

    public void HideInteractBtn()
    {
        interactBtn.SetActive(false);
    }
}
