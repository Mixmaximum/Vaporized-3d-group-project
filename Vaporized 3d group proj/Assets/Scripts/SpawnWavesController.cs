using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class SpawnWavesController : MonoBehaviour
{
    [Header("Spawners info")]
    [SerializeField] GameObject enemyPrefab;
    public GameObject[] spawners;
    public EnemySpawn[] enemySpawnScripts;
    [Space(5)]

    [Header("Hud info")]
    [SerializeField] private TextMeshProUGUI waveTimerText;
    [SerializeField] private TextMeshProUGUI waveNumberText;
    [Space(5)]

    [Header("Wave Info")]
    [SerializeField] private float waveTimer;
    [SerializeField] float addedDifficulty;
    [Space(5)]

    private int waveNumber;
    private float currentWaveTime;
    private float activeDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        enemySpawnScripts = new EnemySpawn[spawners.Length];
        for (int i = 0; i < spawners.Length; i++)
        {
            enemySpawnScripts[i] = spawners[i].GetComponent<EnemySpawn>();
        }
        waveNumber = 1;
        currentWaveTime = waveTimer;
        waveNumberText.text = ("Wave: ") + waveNumber;
    }

    // Update is called once per frame
    void Update()
    {
        currentWaveTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentWaveTime / 60);
        int seconds = Mathf.FloorToInt(currentWaveTime % 60);
        waveTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (currentWaveTime <= 0)
        {
            waveNumber++;
            currentWaveTime = waveTimer;
            waveNumberText.text = ("Wave: ") + waveNumber; 
            activeDifficulty = waveNumber * (1 + addedDifficulty);
            enemyPrefab.GetComponent<EnemyHealth>().health += activeDifficulty;
            enemyPrefab.GetComponent<NavMeshAgent>().speed += activeDifficulty;

            for (int i = 0; i < spawners.Length; i++)
            {
                enemySpawnScripts[i].spawnAmount = enemySpawnScripts[i].spawnAmount + Mathf.RoundToInt(activeDifficulty);
            }
        }
    }
}
