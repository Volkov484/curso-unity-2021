using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    [Tooltip("Prefab de enemigo a generar")]
    public GameObject prefab;
    [Tooltip("Tiempo de inicio y de fin de oleada")]
    public float startTime, endTime;
    [Tooltip("Tiempo entre generacion de enemigos")]
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        WaveManager.SharedInstance.waves.Add(this);
        InvokeRepeating("SpawnEnemy",startTime,spawnRate);
        Invoke("EndWave",endTime);
    }

    void SpawnEnemy()
    {
        /*Quaternion q = Quaternion.Euler(0,transform.rotation.y+Random.Range(-45.0f,45.0f),0);
        */
        Instantiate(prefab, transform.position, transform.rotation);
    }

    void EndWave()
    {
        WaveManager.SharedInstance.waves.Remove(this);
        CancelInvoke();
    }
}
