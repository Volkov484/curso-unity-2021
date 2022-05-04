using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask targetLayers;
    public LayerMask obstacleLayers;

    public Collider detectedTarget;
    private void Update()
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position, distance, targetLayers);
        detectedTarget = null;
        //Pasamos el filtro de distancia
        foreach (Collider collider in colliders)
        {
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
            //Angulo que forman el vector vision con el vector objetivo
            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);
            if (angleToCollider < angle)
            {
                //TODO; objeto en el angulo de vision
                //Comprobamos que en la linea de vision no hay obstaculos
                if (!Physics.Linecast(transform.position,collider.bounds.center, out RaycastHit hit,obstacleLayers))
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    detectedTarget = collider;
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
        Gizmos.color = Color.red;
        Vector3 rightDir = Quaternion.Euler(0,angle,0)*transform.forward;
        Gizmos.DrawRay(transform.position,rightDir*distance);
        Vector3 leftDir = Quaternion.Euler(0,-angle,0)*transform.forward;
        Gizmos.DrawRay(transform.position,leftDir*distance);
    }
}
