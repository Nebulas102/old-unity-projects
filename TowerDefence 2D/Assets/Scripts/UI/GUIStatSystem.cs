using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIStatSystem : MonoBehaviour {

    private TextMeshProUGUI score;
    private  GameObject god;

    // Use this for initialization
    void Start () {
        score = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        this.god = GameObject.Find("God");
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Health: " + this.god.GetComponent<VariableHandler>().health;
        score.text += "Gold: " + this.god.GetComponent<VariableHandler>().gold;
        score.text += "Score: " + this.god.GetComponent<VariableHandler>().score;
    }
}
