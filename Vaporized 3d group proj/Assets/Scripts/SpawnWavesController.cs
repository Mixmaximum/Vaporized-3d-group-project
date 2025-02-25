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
    private float defaultEnemyHp;
    private float defaultEnemySpeed;
    public float currentHP;
    public float currentSpeed;
    private float spawnIncrease = 1;
    // Start is called before the first frame update
    void Start()
    {
        defaultEnemyHp = enemyPrefab.GetComponent<EnemyHealth>().health;
        currentHP = defaultEnemyHp;
        defaultEnemySpeed = enemyPrefab.GetComponent<NavMeshAgent>().speed;
        currentSpeed = defaultEnemySpeed;
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        enemySpawnScripts = new EnemySpawn[spawners.Length];
        for (int i = 0; i < spawners.Length; i++)
        {
            enemySpawnScripts[i] = spawners[i].GetComponent<EnemySpawn>();
        }
        waveNumber = 1;
        currentWaveTime = waveTimer;
        waveNumberText.text = ("Wave: ") + waveNumber;
        activeDifficulty = 1 + addedDifficulty;
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
            //enemyPrefab.GetComponent<EnemyHealth>().health += activeDifficulty;
            currentHP *= activeDifficulty;
            currentSpeed *= activeDifficulty;
            spawnIncrease *= activeDifficulty;
            //enemyPrefab.GetComponent<NavMeshAgent>().speed += activeDifficulty;

            for (int i = 0; i < spawners.Length; i++)
            {
                enemySpawnScripts[i].spawnAmount = enemySpawnScripts[i].spawnAmount + Mathf.RoundToInt(spawnIncrease);
            }
        }
    }
    private void OnApplicationQuit()
    {
        enemyPrefab.GetComponent<EnemyHealth>().health = defaultEnemyHp;
        enemyPrefab.GetComponent<NavMeshAgent>().speed = defaultEnemySpeed;
    }
}
