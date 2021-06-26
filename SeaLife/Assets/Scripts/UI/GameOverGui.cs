using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverGui : MonoBehaviour
{
    private float circleRadius;
    public float spd;
    public GameObject MaskImg;
    public GameObject NameTxt;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = MaskImg.GetComponent<Image>().material;
    }

    IEnumerator Mask()
    {
        circleRadius = 600;
        MaskImg.SetActive(true);

        while (circleRadius > 0)
        {
            circleRadius -= spd;
            mat.SetFloat("_RenderDistance", circleRadius);

            yield return null;
        }

        // 复活
        FindObjectOfType<PlayerController>().PlayerReborn();

        NameTxt.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        NameTxt.SetActive(false);

        while (circleRadius < 600)
        {
            circleRadius += spd;
            mat.SetFloat("_RenderDistance", circleRadius);

            yield return null;
        }
        MaskImg.SetActive(false);
    }

    public void Play()
    {
        StartCoroutine("Mask");
    }

}
