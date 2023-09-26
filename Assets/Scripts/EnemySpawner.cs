using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    float maxTimeLife = 4f;

    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext){
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-7.2f,13.5f);

            Vector3 spawnPosition = new Vector3(rand,18f,21.09f);
            GameObject meteor = Instantiate(asteroidPrefab,spawnPosition,Quaternion.identity);
            Destroy(meteor,maxTimeLife);
        }
    }
}
