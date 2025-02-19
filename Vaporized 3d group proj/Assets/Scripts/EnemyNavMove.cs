using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMove : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    [SerializeField]
    float chaseDistance = 10;
    [SerializeField] float genChaseDist = 10;
    Vector3 home;
    GameObject generator;
    bool prioritizePlayer;
    int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        generator = GameObject.FindGameObjectWithTag("Generator");
        randomNum = Random.Range(0, 10);
        if (randomNum >= 5)
        {
            prioritizePlayer = true;
        }
        else
        {
            prioritizePlayer = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generator.GetComponent<Generator>().isCharging == true && prioritizePlayer == false)
        {
            Vector3 dir = player.transform.position - transform.position;
            if (dir.magnitude <= genChaseDist)
            {
                agent.destination = player.transform.position;
            }
            else
            {
                agent.destination = generator.transform.position;
            }
        }
        else if (prioritizePlayer || generator.GetComponent<Generator>().isCharging == false)
        {
            Vector3 dir = player.transform.position - transform.position;
            if (dir.magnitude <= chaseDistance)
            {
                agent.destination = player.transform.position;
            }
            else if (generator.GetComponent<Generator>().isCharging == true)
            {
                agent.destination = generator.transform.position;
            }
            else
            {
                agent.destination = home;
            }
        }
    }
}
