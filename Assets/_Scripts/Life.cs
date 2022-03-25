using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float amount;


    public UnityEvent onDead;
    
    public float Amount
    {
        get => amount;
        set
        {
            amount = value;
            if (amount <= 0)
            {
                onDead.Invoke();

            }
        }
    }

}
