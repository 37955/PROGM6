using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> enemies = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnEnemies(100);
        }

        if (!IsInvoking("SpawnEnemiesPerSecond"))
        {
            InvokeRepeating("SpawnEnemiesPerSecond", 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClearEnemies();
        }
    }

    void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemies.Add(newEnemy);
        }
    }
    void SpawnEnemiesPerSecond()
    {
        SpawnEnemies(3);
    }
    void ClearEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
    }
}