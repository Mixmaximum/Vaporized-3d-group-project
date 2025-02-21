using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [Header ("SpawnRange")]
    [SerializeField] float spawnRangeX;
    [SerializeField] float spawnRangeZ;
    [Space(5)]

    [Header ("Spawn Info")]
    [SerializeField] public float spawnRate = 2;
    [SerializeField] public int spawnAmount;
    [Space(5)]

    float currentTime;
    float spawnCounter;
    private Transform Transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer();
    }

    void SpawnTimer()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnRate)
        {
            
            for (int i = 0; i < spawnAmount; i++)
            {
                Vector3 randomPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
                randomPos.x += Random.Range(-spawnRangeX, spawnRangeX);
                randomPos.z += Random.Range(-spawnRangeZ, spawnRangeZ);
                Instantiate(enemy, randomPos, Quaternion.identity);
            }
            currentTime = 0;
           
        }
    }
}
