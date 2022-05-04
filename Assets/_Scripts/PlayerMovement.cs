using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.Assertions.Must;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    [Range(0, 1000)] 
    private float speed;
    [SerializeField]
    [Range(0, 360)] 
    private float rotationSpeed;

    private Rigidbody _rb;
    private Animator _animator;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent <Animator>();
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
        _rb.AddRelativeForce(dir.normalized*space);
        float angle = rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(0,mouseX*angle,0);
        //FUERZA DE ROTACION
        _rb.AddRelativeTorque(0,mouseX*angle,0);
        
        
        _animator.SetFloat("MoveX", horizontal);
        _animator.SetFloat("MoveY", vertical);
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            _animator.SetFloat("Velocity", _rb.velocity.magnitude);
        }
        else
        {
            if (Mathf.Abs(horizontal)<0.01f&&Mathf.Abs(vertical)<0.01f)
            {
                _animator.SetFloat("Velocity", 0);
            }
            else
            {
                _animator.SetFloat("Velocity", 0.015f);
            }
            
        }
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
