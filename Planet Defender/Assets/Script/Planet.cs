using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public int health;
    public int score;
    public int speed;
    
    public int tier = 1;

    public GameObject target;
    public GameObject heartPrefab;


    private GameObject hpHeart;
    
    public void Start()
    {
        hpHeart = GameObject.Find("HP Hearts");
    }

    public void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime * 10, 0);

        if (this.health <= 0 && Time.timeScale > 0f)
        {
            Debug.Log(Time.timeScale);
            GameObject.Find("God").GetComponent<GameEventController>().GameOver(this.score);
        }

        if (this.score >= (20 * this.tier)) {
            if ((Time.timeScale + 0.1f) <= 2)
            {
                Time.timeScale += 0.1f;
                this.tier++;
            }
        }
    }

    public void Heal(int healing)
    {
        this.health = healing;
        for (int i = 0; i < this.health; i++) {
            GameObject life = Instantiate(heartPrefab, hpHeart.transform.position, new Quaternion(0, 0, 0, 0), hpHeart.transform);
            life.transform.localScale = new Vector3(1, 1, 1);
            life.transform.localPosition = new Vector3(0, 0.04f - (0.04f * i), 0);
        }
    }

    public void Damage()
    {
        if (this.health >= 0)
        {
            Destroy(hpHeart.transform.GetChild(0).gameObject);
        }
    }
}
