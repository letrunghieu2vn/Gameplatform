using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> enemies;
    public List<bool> spawnHaveEnemies;

    public List<float> timeToSpawn;
    public float timeToSpawnSetting;

    public static SpawnPoint instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Create(i);
        }
    }

    private void Update()
    {
        for (int i = 0; i < timeToSpawn.Count; i++)
        {
            if (timeToSpawn[i] > 0f && !spawnHaveEnemies[i])
                timeToSpawn[i] -= Time.deltaTime;
            else if (timeToSpawn[i] < 0f && !spawnHaveEnemies[i])
                Create(i);
        }

    }

    void Create(int index) {
        if (timeToSpawn[index] <= 0f)
        {
            int enemi = Random.Range(0, enemies.Count);
            GameObject spawn = Instantiate(enemies[enemi], spawnPoints[index].position, Quaternion.identity, spawnPoints[index]);
            spawn.GetComponent<Enemy>().mySpawnPoint = spawnPoints[index];
            timeToSpawn[index] = timeToSpawnSetting;
            spawnHaveEnemies[index] = true;
        }
    }

    public void ChangeTime(Transform _spawnPoint) {
        int index = IndexOfTransform(_spawnPoint);
        if (index == -1)
            return;

        ChangeHaveEnemy(index, false);

    }

    void ChangeHaveEnemy(int index,bool _bool) {
        spawnHaveEnemies[index] = _bool;
    }

    int IndexOfTransform(Transform _transformCheck) {
        return spawnPoints.IndexOf(_transformCheck);
    }

}
