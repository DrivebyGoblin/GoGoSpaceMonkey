using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Bullet> onBulletCollided;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet)
        {
            onBulletCollided?.Invoke(bullet);
            this.gameObject.SetActive(false);
        }

        

    }

    private void Start()
    {
        
    }

}
