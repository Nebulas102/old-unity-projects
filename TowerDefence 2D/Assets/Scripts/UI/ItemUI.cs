using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemUI : MonoBehaviour {

    public GameObject Tower;

    public void setImage(Sprite sprite)
    {
        GameObject imageUI = this.gameObject.transform.GetChild(0).gameObject;
        Debug.Log(imageUI);
        SpriteRenderer[] imageSpriteRender = imageUI.GetComponents<SpriteRenderer>();
        imageSpriteRender[0].sprite = sprite;
    }

    public void setTitle(string name, int cost)
    {
        GameObject titleUI = this.gameObject.transform.GetChild(1).gameObject;
        TextMeshProUGUI titleText = titleUI.GetComponent<TextMeshProUGUI>() ?? titleUI.gameObject.AddComponent<TextMeshProUGUI>();
        titleText.text = name;
        titleText.text += ": " + cost;
    }

}
