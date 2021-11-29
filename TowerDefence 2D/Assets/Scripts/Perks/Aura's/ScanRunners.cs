using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanRunners : MonoBehaviour {

    public List<GameObject> targets = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Boss"))
        {
            this.targets.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Boss"))
        {
            this.targets.RemoveAt(this.targets.IndexOf(collision.gameObject));
        }
    }
}
