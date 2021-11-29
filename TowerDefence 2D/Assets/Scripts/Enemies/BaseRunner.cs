using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseRunner : MonoBehaviour
{

    public float baseHealth;
    public float baseSpeed;
    public int points;
    public Color finish;
    public Image healthBar;

    public float health;
    private float speed;
    private int progression;
    private List<GameObject> objective;

	// Use this for initialization
	public void Start () {

        this.health = this.baseHealth;
        this.speed = this.baseSpeed;

        this.objective = new List<GameObject>();
        bool all = false;

        for (int i = 0; all == false; i++)
        {
            if (GameObject.Find("Point (" + i + ")") != null)
            {
                objective.Add(GameObject.Find("Point (" + i + ")"));
            }
            else
            {
                all = true;
            }
        }
        
        objective[objective.Count - 1].GetComponent<MeshRenderer>().material.color = finish;
    }
	
	// Update is called once per frame
	public void Update () {
        Quaternion neededRotation = Quaternion.LookRotation(Vector3.forward, (GameObject.Find("Point (" + (this.progression) + ")").transform.position) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, 5f * Time.deltaTime);

        if (this.health <= 0) {
            GameObject God = GameObject.Find("God");
            God.GetComponent<VariableHandler>().score += this.points;
            God.GetComponent<VariableHandler>().gold += this.points;

            Destroy(this.gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, objective[progression].transform.position, (speed * Time.deltaTime));
        if (transform.position.x == objective[progression].transform.position.x && transform.position.y == objective[progression].transform.position.y) {
            if (progression + 1 < objective.Count)
            {
                this.progression++;
            }
            else
            {
                GameObject God = GameObject.Find("God");
                God.GetComponent<VariableHandler>().health--;

                Destroy(this.gameObject);
            }
        }

        healthBar.fillAmount = health / baseHealth;

    }

    public void heal(int amount)
    {
        if ((this.health + amount) >= baseHealth)
        {
            this.health = baseHealth;
        }
        else {
            this.health += amount;
        }
    }

    public void damage(int amount)
    {
        this.health -= amount;
    }

    public float getHealth()
    {
        return this.health;
    }

    public float getSpeed()
    {
        return this.speed;
    }
}
