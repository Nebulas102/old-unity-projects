
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAura : MonoBehaviour {

    public GameObject aura;
    public int healing;
    public float delay;

	// Use this for initialization
	void Start () {
        GameObject healingAura = Instantiate(aura, transform.position, transform.rotation, this.transform);
        healingAura.GetComponent<HealList>().healing = healing;
        healingAura.GetComponent<HealList>().delay = delay;

        healingAura.GetComponent<HealList>().targets.Add(this.gameObject);
    }
}
