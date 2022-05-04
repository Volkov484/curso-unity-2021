using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshTest : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform baseTransform;


    private void Start()
    {
        baseTransform = GameObject.FindWithTag("Base").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
    }
}
