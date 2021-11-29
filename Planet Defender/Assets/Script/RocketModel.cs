using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketModel : MonoBehaviour {

    public float rotationSpeed;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, this.rotationSpeed * Time.deltaTime, 0);
    }
}
