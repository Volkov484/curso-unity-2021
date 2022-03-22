using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance;
    
    [Tooltip("Puntuacion d ela partida actual")]
    [SerializeField]
    private int amount;
    public int Amount
    {
        get => amount;
        set => amount = value;
    }

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.LogWarning("Score manager duplicado, debe ser destruido", gameObject);
            Destroy(gameObject);
        }
    }
}
