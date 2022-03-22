using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    [Range(0, 1000)] 
    private float speed;
    [SerializeField]
    [Range(0, 360)] 
    private float rotationSpeed;

    private Rigidbody rb;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float space = speed * Time.deltaTime;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        //transform.Translate(dir.normalized*space);
        //FUERZA DE TRANSLACION
        rb.AddRelativeForce(dir.normalized*space);
        float angle = rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(0,mouseX*angle,0);
        //FUERZA DE ROTACION
        rb.AddRelativeTorque(0,mouseX*angle,0);

/*
        if (Input.GetKey(KeyCode.W))
        { this.transform.Translate(0, 0, space);
        }
        if (Input.GetKey(KeyCode.A))
        { this.transform.Translate(-space, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)) 
        { this.transform.Translate(space, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        { this.transform.Translate(0, 0, -space);
        }
*/
    }
    
}
