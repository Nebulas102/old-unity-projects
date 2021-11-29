using Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public double waveDelayLength;
    public int wave = 0;
    public Wave[] waveList;

    public TextAsset waveFile;

    protected List<List<GameObject>> enemyWave;
    protected List<List<int>> enemyWaveCount;
    protected List<List<float>> EnemyWaveSpawnChance;

    private List<int> usedIndexes;
    private List<int> enemyWaveEnemy;
    private List<double> enemyWaveSpawn;

    private double spawnDelay;
    private double countdown = 0;
    private double waveDelay = 10;
    private bool waveInitiated = false;
    private bool waveEnded = true;

    public void Start()
    {
        //string filePath = Path.Combine(Application.streamingAssetsPath, "../Json/waves.json");
        //string dataAsJson = File.ReadAllText(waveFile.ToString());
        this.waveList = JsonHelper.getJsonArray<Wave>(waveFile.ToString());
    }

    // Use this for initialization
    public void Update()
    {
        if (this.countdown > 0.0f)
        {
            for (int i = 0; i < this.enemyWaveSpawn.Count; i++) {
                if (enemyWaveSpawn[i] >= this.countdown && !this.usedIndexes.Contains(i)) {
                    this.usedIndexes.Add(i);
                    Instantiate(this.enemies[enemyWaveEnemy[i]], transform.position, Quaternion.identity);
                }
            }

            this.countdown -= Time.deltaTime;
        } else if (this.waveInitiated == true) {
            this.waveInitiated = false;
            this.endWave();
        }

        if (this.waveEnded == true) {
            this.waveDelay -= Time.deltaTime;
            if (this.waveDelay <= 0.0f) {
                this.wave++;
                this.initWave(this.wave);
                this.waveEnded = false;
            }
        }
    }

    public void initWave(int wave) {
        Debug.Log("init wave");
        Debug.Log("Wave: " + wave);

        this.enemyWaveSpawn = new List<double>();
        this.enemyWaveEnemy = new List<int>();

        this.usedIndexes = new List<int>();

        if (this.waveList[wave].bossWave == true)
        {
            Debug.Log("is boss wave");

            for (int i = 0; i < this.waveList[wave].enemies.Count; i++)
            {
                for (int n = 0; n < this.waveList[wave].enemyAmount[i]; n++)
                {
                    this.enemyWaveEnemy.Add(this.waveList[wave].enemies[i]);
                    if (this.waveList[wave].bossEnemyIndex.Contains(this.waveList[wave].enemies[i]))
                    {
                        Debug.Log("Boss spawn time");
                        Debug.Log(Random.Range(39, this.waveList[wave].bossSpawnChance));
                        
                        this.enemyWaveSpawn.Add(Random.Range(this.waveList[wave].spawnChance - this.waveList[wave].bossSpawnChance, this.waveList[wave].spawnChance));
                    }
                    else
                    {
                        this.enemyWaveSpawn.Add(Random.Range(0, this.waveList[wave].spawnChance));
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < this.waveList[wave].enemies.Count; i++)
            {
                for (int n = 0; n < this.waveList[wave].enemyAmount[i]; n++)
                {
                    this.enemyWaveEnemy.Add(this.waveList[wave].enemies[i]);
                    this.enemyWaveSpawn.Add(Random.Range(0, this.waveList[wave].spawnChance));
                }
            }
        }

        this.waveInitiated = true;
        this.countdown = this.waveList[wave].spawnChance;
        Debug.Log("start wave");
    }

    public void endWave() {
        Debug.Log("end wave");

        this.waveDelay = waveDelayLength;
        this.waveEnded = true;
    }
}
