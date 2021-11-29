using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageModifier : MonoBehaviour {

    public int damage;

    private void OnDestroy()
    {
        if (this.GetComponent<BaseRunner>().getHealth() > 0)
        {
            GameObject God = GameObject.Find("God");
            God.GetComponent<VariableHandler>().health -= (damage - 1);
        }
    }
}
