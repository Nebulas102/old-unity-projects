using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTower : BaseTower {

    private void Update()
    {
        if (this.target != null)
        {

            Quaternion neededRotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, this.speed[this.tier] * Time.deltaTime);

            if (this.countdown <= 0)
            {
                this.countdown = this.reload[this.tier];

                GameObject barrel = this.gameObject.transform.GetChild(0).gameObject;

                GameObject shot = Instantiate(this.ammo[this.tier], new Vector3(barrel.transform.position.x, barrel.transform.position.y, barrel.transform.position.z), Quaternion.identity);
                shot.GetComponent<BaseBullet>().target = this.target;
                shot.transform.rotation = barrel.transform.rotation;
            }

            this.countdown -= Time.deltaTime;
        }
    }
}
