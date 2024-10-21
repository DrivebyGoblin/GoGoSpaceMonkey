using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinish : MonoBehaviour
{
    [SerializeField] private EnemyRow _enemyRow;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy)
        {
            enemy.gameObject.SetActive(false);
            

            
        }
    }
}
