using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBullet : BaseBullet {

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;

        this.destroyTime -= Time.deltaTime;

        if (this.destroyTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
