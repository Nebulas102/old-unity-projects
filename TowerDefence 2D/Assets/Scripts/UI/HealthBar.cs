using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image healthBar;
    private int playerHealth = GameObject.Find("God").GetComponent<VariableHandler>().health;
    private int updateHealth;

    // Use this for initialization
    void Start()
    {
        float updateHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = updateHealth / playerHealth;
    }
}
