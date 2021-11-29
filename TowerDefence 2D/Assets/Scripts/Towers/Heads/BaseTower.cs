using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour {

    public string name;
    public List<float> speed;
    public List<float> reload;
    public List<Sprite> sprite;
    public List<GameObject> ammo;
    public List<int> cost;
    public int tier = 0;

    protected float countdown = 0;
    protected Transform target;
    protected List<Transform> targets;

    public void Start()
    {
        this.targets = new List<Transform>();
    }

    public void upgrade()
    {
        if ((this.tier + 1) < sprite.Count)
        {
            GameObject God = GameObject.Find("God");
            if ((God.GetComponent<VariableHandler>().gold - this.cost[this.tier]) >= 0)
            {
                God.GetComponent<VariableHandler>().gold -= this.cost[this.tier];
                this.tier++;
                SpriteRenderer[] test = GetComponents<SpriteRenderer>();
                test[0].sprite = sprite[this.tier];
                Debug.Log("change sprite");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Boss"))
        {
            this.targets.Add(collision.transform);
            this.target = collision.transform;
            this.target = getTarget(this.targets);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Boss"))
        {
            this.targets.RemoveAt(this.targets.IndexOf(collision.transform));
            this.target = getTarget(this.targets);
        }
    }

    public Transform getTarget(List<Transform> list) {
        if (list.Count > 0)
        {
            return list[0];
        }
        else
        {
            return null;
        }
    }
}
