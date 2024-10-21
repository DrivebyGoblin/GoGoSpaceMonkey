using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public static event Action<Bullet> onBulletCollided;
    public static event Action onEnemyKilled;
    [SerializeField] private ParticleSystem _particle;



    private void Death()
    {

        print("Åםולט גל‎נ");
        //_particle.gameObject.SetActive(true);
        //_particle.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        PlayerDeath player = collision.gameObject.GetComponent<PlayerDeath>();

        if (player)
        {
            Death();
            player.Death();
        }


        if (bullet)
        {
            Death();
            onBulletCollided?.Invoke(bullet);
            onEnemyKilled?.Invoke();
            this.gameObject.SetActive(false);
        }





    }
}
