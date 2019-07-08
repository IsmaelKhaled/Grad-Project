using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWalking : MonoBehaviour
{
    public GameObject source;
    public GameObject dest;
    public float MinToDestroy = 2f;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.5f;
        gameObject.SetActive(true);
        agent.speed = UnityEngine.Random.Range(1f, 2f);
        gameObject.AddComponent<NavMeshObstacle>();
        GetComponent<NavMeshObstacle>().shape = NavMeshObstacleShape.Capsule;
        GetComponent<NavMeshObstacle>().center = new Vector3(0, 1, 0);
        //agent.acceleration = 4;
        //GetComponent<WalkingSound>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(dest.transform.position);
        float dist = agent.remainingDistance;
        //Debug.Log(agent.name + " " + agent.destination);
        if (dist <= agent.stoppingDistance && !agent.pathPending)
        {
            NPCSpawner.SpawnedNpcCount--;
            Destroy(gameObject);
        }
        Destroy(gameObject, MinToDestroy * 60);
    }
}
