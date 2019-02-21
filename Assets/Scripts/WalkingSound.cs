using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingSound : MonoBehaviour {


    NavMeshAgent navMesh;
    float stepCycle, nextStep;
    public float stepInterval = 2f;
    AudioSource audioSource;
    public AudioClip[] walkSound;
    private void Start()
    {

        navMesh = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        stepCycle = 0f;
        nextStep = stepCycle / 2f;
    }
    private void Update()
    {

        ProgressStepCycle(navMesh.velocity.magnitude);
    }
    void ProgressStepCycle(float speed)
    {
        if (navMesh.velocity.sqrMagnitude > 0) 
        {
            stepCycle += (navMesh.velocity.magnitude + (speed)) *
                          Time.fixedDeltaTime;
        }

        if (!(stepCycle > nextStep))
        {
            return;
        }

        nextStep = stepCycle + stepInterval;

        PlayWalkSound();
    }
    void PlayWalkSound()
    {
        /* if (!controller.isGrounded)
         {
             return;
         }*/
        int n = Random.Range(1, walkSound.Length);
        audioSource.clip = walkSound[n];
        audioSource.PlayOneShot(audioSource.clip);
        walkSound[n] = walkSound[0];
        walkSound[0] = audioSource.clip;
    }
}
