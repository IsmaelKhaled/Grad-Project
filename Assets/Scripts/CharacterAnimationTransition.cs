using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimationTransition : MonoBehaviour {
    Animator anim;
    NavMeshAgent navMesh;
    public bool greet = false;
    public bool stand = true;
    public bool typing = false;
    public bool talking = false;
    float speed;
    private void Start()
    {
        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
              
            }
        }

        anim.SetFloat("speed", navMesh.velocity.magnitude);
        if (greet)
        {
            anim.SetTrigger("greet");
            greet = false;
        }
        anim.SetBool("stand", stand);
        anim.SetBool("typing", typing);
        anim.SetBool("talking", talking);
        //Motion();
    }
    
    /*void Motion()
    {

        Vector3 moveVector = Vector3.zero;
        float verticalVelocity = 0f ;
        float speed = 2f;
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        
        moveVector.y = verticalVelocity;


        moveVector.z = Input.GetAxis("Vertical") * speed;
       
        if(moveVector.x!=0 || moveVector.z != 0)
        {
            stand = true;
        }
         if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
         {

            moveVector = moveVector.normalized;
            navMesh.SetDestination(transform.position + moveVector);
            if (navMesh.velocity != Vector3.zero)
            {
                transform.forward = new Vector3(navMesh.velocity.x, 0, navMesh.velocity.z);

            }
        }
    }*/
}
