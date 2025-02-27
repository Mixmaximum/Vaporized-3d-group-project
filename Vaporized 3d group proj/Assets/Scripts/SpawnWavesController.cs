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

    public int waveNumber;
    public float currentWaveTime;
    private float activeDifficulty;
    private float defaultEnemyHp;
    private float defaultEnemySpeed;
    public float currentHP;
    public float currentSpeed;
    public int spawnAmount;

    private GameObject player;
    private GameObject hud;
    private GameObject upgrader;
    private GameObject[] core;
    private GameObject[] interactable;
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
        spawnAmount = enemySpawnScripts[0].spawnAmount;
        player = GameObject.FindGameObjectWithTag("Player");
        hud = GameObject.FindGameObjectWithTag("HUD");
        upgrader = GameObject.FindGameObjectWithTag("Upgrader");
        core = GameObject.FindGameObjectsWithTag("Core");
        interactable = GameObject.FindGameObjectsWithTag("Interactable");
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
            spawnAmount ++;
            //enemyPrefab.GetComponent<NavMeshAgent>().speed += activeDifficulty;

            for (int i = 0; i < spawners.Length; i++)
            {
                enemySpawnScripts[i].spawnAmount = spawnAmount;
            }
            player.GetComponent<PLayerSaveData>().Save();
            hud.GetComponent<HUDSaveData>().Save();
            upgrader.GetComponent<UpgraderSaveData>().Save();
            for (int i = 0; i < core.Length; i++)
            {
                core[i].GetComponent<CoresSaveData>().Save();
            }
            for (int i = 0; i < interactable.Length; i++)
            {
                interactable[i].GetComponent<InteractableSaveData>().Save();
            }
        }
    }
    private void OnApplicationQuit()
    {
        enemyPrefab.GetComponent<EnemyHealth>().health = defaultEnemyHp;
        enemyPrefab.GetComponent<NavMeshAgent>().speed = defaultEnemySpeed;
    }
}
