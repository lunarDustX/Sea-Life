using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour
{
    public GameObject oxygenCircle;
    private Image oxygenFill;
    private float maxOxygen;

    // Start is called before the first frame update
    void Start()
    {
        oxygenFill = oxygenCircle.transform.GetChild(0).GetComponent<Image>();
        maxOxygen = FindObjectOfType<PlayerController>().maxOxygen;
    }

    public void UpdateOxygen(float _oxygen)
    {
        oxygenFill.fillAmount = _oxygen / maxOxygen;
        oxygenCircle.SetActive(_oxygen < maxOxygen);
    }
}
