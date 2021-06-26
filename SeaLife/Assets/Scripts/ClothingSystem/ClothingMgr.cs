using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingMgr : MonoBehaviour
{
    #region Singleton
    public static ClothingMgr Instance;
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

    public Transform avatar;
    private Transform clothingNode;
    private Image virtualHat, virtualTorso;
    //private SpriteRenderer hat, torso;
    private GameObject player;

    Wearable[] clothes, tempClothes;

    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(ClothingType)).Length;
        clothes = new Wearable[numSlots];
        tempClothes = new Wearable[numSlots];

        player = GameObject.FindGameObjectWithTag("Player");
        clothingNode = player.transform.Find("Clothing");
        //hat = player.transform.Find("Hat").GetComponent<SpriteRenderer>();
        //torso = player.transform.Find("Torso").GetComponent<SpriteRenderer>();
        virtualHat = avatar.Find("Hat").GetComponent<Image>();
        virtualTorso = avatar.Find("Torso").GetComponent<Image>();
    }

    // 试穿
    public void TryOn(Wearable _wearable)
    {
        if (_wearable == null) return;

        int slotIndex = (int)_wearable.clothingType;
        tempClothes[slotIndex] = _wearable;

        if (_wearable.icon == null)
        {
            avatar.GetChild(slotIndex).gameObject.SetActive(false);
        }
        else
        {
            avatar.GetChild(slotIndex).gameObject.SetActive(true);
            avatar.GetChild(slotIndex).GetComponent<Image>().sprite = _wearable.icon;
        }

        /*
        switch (_wearable.clothingType)
        {
            case ClothingType.HAT:
                virtualHat.sprite = _wearable.icon;
                break;
            case ClothingType.TORSO:
                virtualTorso.sprite = _wearable.icon;
                break;
        }
        */

    }

    // 
    public void PutOn()
    {

    }

    public void TakeOff()
    {

    }

    // 保存穿搭
    public void SaveStyle()
    {
        clothes = tempClothes;
        for (int i = 0; i < clothes.Length; i++)
        {
            if (clothes[i])
            {
                clothingNode.GetChild(i).GetComponent<SpriteRenderer>().sprite = clothes[i].icon;
            }
            else
            {
                clothingNode.GetChild(i).GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }

}
