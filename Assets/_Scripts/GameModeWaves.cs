using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{
    [SerializeField] private Life playerLife;
    [SerializeField] private Life baseLife;

    private void Awake()
    {
        playerLife.onDeath.AddListener(OnPlayerLose);
        baseLife.onDeath.AddListener(OnPlayerLose);
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(OnPlayerWin);
    }

    void OnPlayerLose()
    {
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
    }

    void OnPlayerWin()
    {
        SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
    }
}


