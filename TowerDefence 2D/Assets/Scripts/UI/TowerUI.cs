using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour {

    public GameObject[] TowerItem;

    public void ClearUI() {
        this.RemoveDisplayedTowers();
        this.RemoveDisplayedUpgrades();
    }

    public void DisplayTowers() {
        int distance = 0;
        foreach (GameObject tower in GameObject.Find("Placement").GetComponent<Placement>().Towers)
        {
            GameObject TowerItemUI = Instantiate(TowerItem[0], new Vector3(this.transform.position.x + distance, this.transform.position.y, 0), Quaternion.identity, this.transform);
            TowerItem option = TowerItemUI.transform.GetChild(0).GetComponent<TowerItem>();
            option.Tower = tower;
            option.setImage(tower.GetComponent<BaseTower>().sprite[0]);
            option.setTitle(tower.GetComponent<BaseTower>().name, tower.GetComponent<BaseTower>().cost[0]);

            distance += 10;
        }
    }

    private void RemoveDisplayedTowers() {
        foreach (GameObject ItemUI in GameObject.FindGameObjectsWithTag("TowerUI"))
        {
            Destroy(ItemUI);
        }
    }

    public void DisplayUpgrades()
    {
        int distance = 0;
        GameObject tower = GameObject.Find("Placement").GetComponent<Placement>().selected;
        BaseTower towerData = tower.transform.GetChild(1).gameObject.GetComponent<BaseTower>();

        GameObject TowerItemUI = Instantiate(TowerItem[1], new Vector3(this.transform.position.x + distance, this.transform.position.y, 0), Quaternion.identity, this.transform);
        UpgradeItem upgrade = TowerItemUI.transform.GetChild(0).GetComponent<UpgradeItem>();
        upgrade.Tower = tower.transform.GetChild(1).gameObject;
        upgrade.setImage(towerData.sprite[towerData.tier + 1]);
        upgrade.setTitle(towerData.name, towerData.cost[towerData.tier + 1]);

        /*for (int i = 1; i < towerData.cost.Count; i++)
        {
            
            GameObject TowerItemUI = Instantiate(TowerItem[1], new Vector3(this.transform.position.x + distance, this.transform.position.y, 0), Quaternion.identity, this.transform);
            UpgradeItem upgrade = TowerItemUI.transform.GetChild(0).GetComponent<UpgradeItem>();
            upgrade.Tower = tower.transform.GetChild(1).gameObject;
            upgrade.setImage(towerData.sprite[i]);
            upgrade.setTitle(towerData.name, towerData.cost[i]);
            

            distance += 5;
        }*/
    }

    private void RemoveDisplayedUpgrades()
    {
        foreach (GameObject ItemUI in GameObject.FindGameObjectsWithTag("TowerUI"))
        {
            Destroy(ItemUI);
        }
    }
}
