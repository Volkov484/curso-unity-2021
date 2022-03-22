using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Cantidad de puntos al derrotar al enemigo")]
    public int pointsAmount = 10;

    private void Start()
    {
        EnemyManager.SharedInstance.enemies.Add(this);
    }

    private void OnDestroy()
    {
        ScoreManager.SharedInstance.Amount += pointsAmount;
        EnemyManager.SharedInstance.enemies.Remove(this);
    }
}
