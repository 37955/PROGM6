using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab;

    public Vector3 minPosition = new Vector3(-5f, 0f, -5f);
    public Vector3 maxPosition = new Vector3(5f, 0f, 5f);

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnTower();
        }
    }


    void SpawnTower()
    {
        float randomX = Random.Range(minPosition.x, maxPosition.x);
        //float randomY = Random.Range(minPosition.y, maxPosition.y);
        float randomZ = Random.Range(minPosition.z, maxPosition.z);

        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);




        GameObject t = Instantiate(towerPrefab, randomPosition, Quaternion.identity);

        float randomY = Random.Range(0.1f, 3f);

        t.transform.localScale = new Vector3(1, randomY, 1);

    }
}
