using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWalking : MonoBehaviour
{
    public GameObject source;
    public GameObject dest;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.5f;
        gameObject.SetActive(true);
        //GetComponent<WalkingSound>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(dest.transform.position);
        float dist = agent.remainingDistance;
        Debug.Log(gameObject.name + " " + dist);
        if (dist <= agent.stoppingDistance && !agent.pathPending)
        {
            NPCSpawner.SpawnedNpcCount--;
            Destroy(gameObject);
        }
    }
}
