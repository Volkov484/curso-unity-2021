using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Cantidad de puntos al derrotar al enemigo")]
    public int pointsAmount = 10;

    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(DestroyEnemy);
    }

    private void Start()
    {
        EnemyManager.SharedInstance.AddEnemy(this);
    }

    private void DestroyEnemy()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");
        Invoke("PlayDestruction", 1);
        Destroy(gameObject, 2);
        ScoreManager.SharedInstance.Amount += pointsAmount;
        EnemyManager.SharedInstance.RemoveEnemy(this);
    }
    
    void PlayDestruction()
    {
        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);
        ParticleSystem explosion = gameObject.GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
}