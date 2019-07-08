﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class PlayerMovment : MonoBehaviour
{
    Vector3 destinationPosition;
    NavMeshAgent agent;
    void OnCollisionEnter(Collision other)
    {
        var otherXDD = other.gameObject.GetComponent<Interactable>();
        if (otherXDD)
        {
            otherXDD.interact();
        }
    }
    public void OnGroundClick(BaseEventData data)
    {
        
             PointerEventData pData = (PointerEventData)data;
             NavMeshHit hit;
             if (NavMesh.SamplePosition(pData.pointerCurrentRaycast.worldPosition, out hit, 4f, NavMesh.AllAreas))
                    destinationPosition = hit.position;
                //else
                //destinationPosition = pData.pointerCurrentRaycast.worldPosition;
                agent.SetDestination(destinationPosition);
       
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
