using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave {

    public List<int> enemies = new List<int>();
    public List<int> enemyAmount = new List<int>();
    public float spawnChance;

    public bool bossWave = false;
    public List<int> bossEnemyIndex = new List<int>();
    public float bossSpawnChance;

}
