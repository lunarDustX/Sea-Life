using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeMgr : MonoBehaviour
{
    #region Singleton
    public static NoticeMgr Instance;
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

    public GameObject NoticeGui;
    public GameObject messagePrefab;

    private List<GameObject> messages = new List<GameObject>();

    public void ShowMessage(string _content)
    {
        foreach (GameObject m in messages)
        {
            m.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 60);
        }

        GameObject message = Instantiate(messagePrefab, NoticeGui.transform);
        message.GetComponentInChildren<Text>().text = _content;
        message.GetComponent<RectTransform>().anchoredPosition = new Vector2(-600, 0);
        messages.Add(message);

        Invoke("DestroyMessage", 2f);
    }

    private void DestroyMessage()
    {
        GameObject message = messages[0];
        messages.RemoveAt(0);
        Destroy(message);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShowMessage("xxxx");
        }
    }
}
