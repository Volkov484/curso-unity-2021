using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Sight))]
public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState{GoToBase,AttackBase,ChasePlayer,AttackPlayer}

    public EnemyState currentState;
    private Sight _sight;
    private Transform baseTransform;
    public float baseAttackDistance, playerAttackDistance;
    private NavMeshAgent agent;
    private void Awake()
    {
        _sight = GetComponent<Sight>();
        baseTransform = GameObject.FindWithTag("Base").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }

    private void update()
    {
        switch (currentState)
        {
            case EnemyState.GoToBase:
                GoToBase();
                break;
            case EnemyState.AttackBase:
                AttackBase();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyState.AttackPlayer:
                AttackPlayer();
                break;
            default:
                //TODO: Caso por defecto
                break;
        }
    }

    void GoToBase()
    {
        print("Ir a Base");
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        if (_sight.detectedTarget!=null)
        {
            currentState = EnemyState.ChasePlayer;
            return;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase<baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase()
    {
        agent.isStopped = true;
        print("Atacar la Base");
    }

    void ChasePlayer()
    {
        print("Perseguir al jugador");
        if (_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        agent.isStopped = false;
        agent.SetDestination(_sight.detectedTarget.transform.position);
        
        
        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if (distanceToPlayer<playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }

    void AttackPlayer()
    {
        print("Atacar al jugador");
        agent.isStopped = true;
        if (_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if (distanceToPlayer > playerAttackDistance*1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

private void OnDrawGizmos()
{
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(transform.position,playerAttackDistance);
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
}
}
