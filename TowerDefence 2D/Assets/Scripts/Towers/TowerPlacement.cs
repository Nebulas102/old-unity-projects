using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour {

    private bool active = false;

    private void OnMouseUp()
    {
        GameObject.Find("Placement").GetComponent<Placement>().selected = this.gameObject;

        if (this.active == false)
        {
            GameObject.Find("BottomUI").GetComponent<TowerUI>().ClearUI();
            GameObject.Find("BottomUI").GetComponent<TowerUI>().DisplayTowers();
        }
        else {
            GameObject.Find("BottomUI").GetComponent<TowerUI>().ClearUI();
            GameObject.Find("BottomUI").GetComponent<TowerUI>().DisplayUpgrades();
        }
    }

    public void placeTower(GameObject Tower)
    {
        if (this.active == false)
        {
            GameObject God = GameObject.Find("God");

            if ((God.GetComponent<VariableHandler>().gold - Tower.GetComponent<BaseTower>().cost[0]) >= 0)
            {
                Quaternion rotation;
                if (transform.rotation.w != 0)
                {
                    rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    rotation = Quaternion.Euler(180, 180, 0);
                }

                this.active = true;
                God.GetComponent<VariableHandler>().gold -= Tower.GetComponent<BaseTower>().cost[0];
                GameObject towerBase = this.gameObject.transform.GetChild(0).gameObject;
                GameObject head = Instantiate(Tower, new Vector3(towerBase.transform.position.x, towerBase.transform.position.y, towerBase.transform.position.z + 1), rotation, this.transform);
            }
        }
        else
        {
            GameObject towerHead = this.gameObject.transform.GetChild(1).gameObject;
            Debug.Log(towerHead);
            towerHead.GetComponent<BaseTower>().upgrade();
        }
    }
}
