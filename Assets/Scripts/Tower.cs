using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 maxScale = new Vector3(2.0f, 2.0f, 2.0f);
    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(minScale.x, maxScale.x);
        float randomY = Random.Range(minScale.y, maxScale.y);
        float randomZ = Random.Range(minScale.z, maxScale.z);

        transform.localScale = new Vector3(randomX, randomY, randomZ);

        Vector3 newPos = transform.position;
        newPos.y = (transform.localScale.y / 2);
        transform.position = newPos;

    }

    // Update is called once per frame
    void Update()
    {
    }
}