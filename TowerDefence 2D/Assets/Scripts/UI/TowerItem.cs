using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerItem : ItemUI
{
    public void onClick()
    {
        Debug.Log("click on UI");

        //say to the game object what tower to use
        Placement Placement = GameObject.Find("Placement").GetComponent<Placement>();
        if (Placement.selected != null)
        {
            Placement.selected.GetComponent<TowerPlacement>().placeTower(Tower);
            GameObject.Find("BottomUI").GetComponent<TowerUI>().ClearUI();
            if ((Placement.selected.transform.GetChild(1).gameObject.GetComponent<BaseTower>().tier + 1) >= Placement.selected.transform.GetChild(1).gameObject.GetComponent<BaseTower>().cost.Count)
            {
                Placement.selected = null;
            }
            else
            {
                GameObject.Find("BottomUI").GetComponent<TowerUI>().DisplayUpgrades();
            }
        }

    }
}
