using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject [] Npcs;
    public GameObject[] SpawnPoints;

    public static int SpawnedNpcCount = 0;
    public int MaxSpawnedNpc = 3;

    public float SpawnRate = 1.5f;

    float timeSincelastSpawn;

    private void Start()
    {
        timeSincelastSpawn = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (SpawnedNpcCount < MaxSpawnedNpc && timeSincelastSpawn<=0)
        {
            int point = UnityEngine.Random.Range(0, SpawnPoints.Length);
            int Npc = UnityEngine.Random.Range(0, Npcs.Length);
            GameObject spawned = Instantiate(Npcs[Npc], SpawnPoints[point].transform.position,Quaternion.identity);
            spawned.AddComponent<NpcWalking>();
            int destpoint = UnityEngine.Random.Range(0, SpawnPoints.Length); 
            while(destpoint == point)
            {
                destpoint = UnityEngine.Random.Range(0, SpawnPoints.Length);

            }
            spawned.GetComponent<NpcWalking>().dest = SpawnPoints[destpoint];
            spawned.GetComponent<NpcWalking>().source = SpawnPoints[point];
            SpawnedNpcCount++;
            timeSincelastSpawn = SpawnRate;
            
        }
        else
        {
            timeSincelastSpawn -= Time.deltaTime;
        }
    }
}
