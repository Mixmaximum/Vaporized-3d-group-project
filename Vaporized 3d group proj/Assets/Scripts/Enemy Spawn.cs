using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnRate = 2;
    [SerializeField] float spawnAmount;
    float currentTime;
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
            Vector3 randomPos = new Vector3 (0, 0, 0);
            randomPos.x = Random.Range(0, 1);
            randomPos.y = Random.Range(0, 1);
            Instantiate(enemy, randomPos, Quaternion.identity);
            currentTime = 0;
        }
    }
}
