using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject shootingPoint;

    private Animator _animator;
    public int bulletsAmount;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            _animator.SetTrigger("Shot Bullet");
            if (bulletsAmount > 0)
            {
                Invoke("Firebullet", 0.4f);
            }
            
            
            /*
            GameObject bullet = Instantiate(prefab);
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            Destroy(bullet, 2);
            */
        } 
    }
    
    
    void Firebullet()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetFirstPooledObject();
        bullet.layer = LayerMask.NameToLayer("Player Bullet");
        bullet.transform.position = shootingPoint.transform.position;
        bullet.transform.rotation = shootingPoint.transform.rotation;
        bullet.SetActive(true);
        bulletsAmount--;
    }
}
