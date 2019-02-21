using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimationTransition : MonoBehaviour {
    Animator anim;
    //CharacterController controller;
    NavMeshAgent navMesh;    
    float stepCycle, nextStep;
    public float stepInterval = 2f;
    AudioSource audioSource;
    public AudioClip[] walkSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        //controller = GetComponent<CharacterController>();
        navMesh = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        stepCycle = 0f;
        nextStep = stepCycle / 2f;
    }
    private void Update()
    {
        anim.SetFloat("speed",navMesh.velocity.magnitude );//controller.velocity.magnitude
        ProgressStepCycle(navMesh.velocity.magnitude);//controller.velocity.magnitude
    }
    void ProgressStepCycle(float speed)
    {
        if (navMesh.velocity.sqrMagnitude > 0) //controller.velocity.sqrMagnitude >0 && (moveDirection.x != 0 || moveDirection.y != 0)
        {
            stepCycle += (navMesh.velocity.magnitude + (speed )) *
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
    /*void Motion()
    {

        Vector3 moveVector = Vector3.zero;
        float verticalVelocity = 0f ;
        float gravity = 9.8f;
        float speed = 2f;
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime * 0.5f;
            
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;

        }
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical") * speed;

        controller.Move(moveVector * Time.deltaTime);

        if (controller.velocity != Vector3.zero)
        {
            transform.forward = new Vector3(controller.velocity.x, 0, controller.velocity.z);

        }
    }*/
}
