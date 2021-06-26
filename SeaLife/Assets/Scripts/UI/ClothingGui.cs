using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingGui : MonoBehaviour
{
    public Button backBtn;
    public Button saveBtn;

    private ClothingMgr clothingMgr;

    // Start is called before the first frame update
    void Start()
    {
        clothingMgr = ClothingMgr.Instance;

        backBtn.onClick.AddListener(BackBtnClicked);
        saveBtn.onClick.AddListener(SaveBtnClicked);
    }

    private void Close()
    {
        this.gameObject.SetActive(false);
    }

    private void BackBtnClicked()
    {
        Close();
    }

    private void SaveBtnClicked()
    {
        clothingMgr.SaveStyle();
        Close();
    }
}
