using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMgr : MonoBehaviour
{
    #region Singleton
    public static DialogueMgr Instance;
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

    public GameObject chatBubble;
    public Text displayTxt;
    public Text nameTxt;

    private Dialogue dialogue;
    private GameObject talkTo;

    private int index;
    private IEnumerator coroutine;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && chatBubble.activeSelf)
        {
            NextSentence();
        }

        if (chatBubble.activeSelf && talkTo != null)
        {
            chatBubble.transform.position = Camera.main.WorldToScreenPoint(talkTo.transform.position + new Vector3(0, 1, 0));
        }
    }

    // 开始对话
    public void StartDialogue(Dialogue _dialogue, GameObject _person)
    {
        talkTo = _person;
        dialogue = _dialogue;

        index = -1;
        nameTxt.text = dialogue.name;   
        displayTxt.text = "";
        chatBubble.SetActive(true);

        NextSentence();
    }

    // 下一句
    public void NextSentence()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        if (index < 0 || string.Equals(displayTxt.text, dialogue.sentences[index]))
        {
            index++;
            if (index == dialogue.sentences.Length)
            {
                chatBubble.SetActive(false);
                return;
            }
            displayTxt.text = "";
            coroutine = Type();
            StartCoroutine(coroutine);
        }
        else
        {
            displayTxt.text = dialogue.sentences[index];
        }

    }

    // 逐字显示
    IEnumerator Type()
    {
        string sentence = dialogue.sentences[index];
        foreach (char letter in sentence.ToCharArray())
        {
            displayTxt.text += letter;
            yield return new WaitForSeconds(0.06f);
        }
    }
}
