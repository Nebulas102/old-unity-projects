using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealList : ScanRunners {

    public float delay;
    public int healing;

    private float countdown;

    private void Update()
    {
        if (this.countdown <= 0)
        {
            foreach (GameObject target in this.targets)
            {
                target.GetComponent<BaseRunner>().heal(healing);
            }

            this.countdown = this.delay;
        }
        else {
            this.countdown -= Time.deltaTime;
        }
    }
}
