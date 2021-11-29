using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour {

    public int speed;
    public int damage;
    public Transform target;
    public double destroyTime = 0.4;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Boss"))
        {
            GameObject enemy = collision.gameObject;

            enemy.GetComponent<BaseRunner>().damage(this.damage);
            Destroy(this.gameObject);
        }
    }
}
