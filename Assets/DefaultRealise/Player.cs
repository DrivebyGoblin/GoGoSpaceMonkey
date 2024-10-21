using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ShotSystem _shotSystem;
    public ShotSystem ShotSystem { get => _shotSystem; }
    private BulletsPool pool;


    private void Awake()
    {
        pool = GetComponent<BulletsPool>();
        _shotSystem = new SingleShot();
    }



    public void ChangeGun(ShotSystem _system)
    {
        _shotSystem = _system;
    }


    public void Shot()
    {
        _shotSystem.Shoot(pool);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }

        //print(_shotSystem);
    }
}
