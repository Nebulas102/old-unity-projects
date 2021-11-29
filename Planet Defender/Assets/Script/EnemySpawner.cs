using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject rocket;
    public List<GameObject> rockets;

    private float screenWidth = Screen.width;
    private float screenHeight = Screen.height;

    public float spawnRate;

    private float countdown;

    private void Start()
    {
        this.countdown = this.spawnRate;
    }

    void Update()
    {
        if (this.countdown >= 0)
        {
            this.countdown -= Time.deltaTime;
        }
        else
        {
            switch (Random.Range(0, 2)) {
                case 0:
                    Instantiate(rockets[Random.Range(0, this.rockets.Count)], Camera.main.ScreenToWorldPoint(new Vector3(this.screenWidth, this.screenHeight / Random.Range(1, 6), 10)), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(rockets[Random.Range(0, this.rockets.Count)], Camera.main.ScreenToWorldPoint(new Vector3(0, this.screenHeight / Random.Range(1, 6), 10)), Quaternion.identity);
                    break;
            }

            //Instantiate(rocket, Camera.main.ScreenToWorldPoint(new Vector3(this.screenWidth / Random.Range(1, 10), this.screenHeight / Random.Range(1, 10), 10)), Quaternion.identity);
            this.countdown = this.spawnRate;
        }
    }
}
