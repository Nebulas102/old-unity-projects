using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour {

	public void ClickTower () {
        this.transform.GetChild(0).GetComponent<TowerItem>().onClick();
    }

    public void ClickUpgrade()
    {
        this.transform.GetChild(0).GetComponent<UpgradeItem>().onClick();
    }
}
