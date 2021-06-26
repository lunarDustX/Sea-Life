using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapGui : MonoBehaviour
{
    public Button backBtn;
    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(BackBtnClicked);
    }

    private void BackBtnClicked()
    {
        this.gameObject.SetActive(false);
    }
}
