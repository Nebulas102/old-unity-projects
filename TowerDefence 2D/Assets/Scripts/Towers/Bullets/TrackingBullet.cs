using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBullet : BaseBullet {

    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Quaternion neededRotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, rotationSpeed * Time.deltaTime);

            transform.position = Vector2.MoveTowards(transform.position, target.position, (speed * Time.deltaTime));
        }
        else
        {
            Destroy(this.gameObject);
        }

        this.destroyTime -= Time.deltaTime;

        if (this.destroyTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
