using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeItem : ItemUI {

    public void onClick()
    {
        Debug.Log("click on UI");

        //say to the game object what tower to use
        Placement Placement = GameObject.Find("Placement").GetComponent<Placement>();
        if (Placement.selected != null)
        {
            Tower.GetComponent<BaseTower>().upgrade();
            GameObject.Find("BottomUI").GetComponent<TowerUI>().ClearUI();
            if ((Tower.GetComponent<BaseTower>().tier + 1) >= Tower.GetComponent<BaseTower>().cost.Count)
            {
                Placement.selected = null;
            }
            else {
                GameObject.Find("BottomUI").GetComponent<TowerUI>().DisplayUpgrades();
            }
        }

    }
}
