using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinish : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.SetActive(false);
        }
    }
}