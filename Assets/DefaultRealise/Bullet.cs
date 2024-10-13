using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed;
    private Vector3 _direction;
    
    


    public void BulletMovement(Vector3 direction, float speed)
    {

        
        _direction = direction;
        _bulletSpeed = speed;
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    private void Update()
    {
        BulletMovement(_direction, _bulletSpeed);
        
    }
}
