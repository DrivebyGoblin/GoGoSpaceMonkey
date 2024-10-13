using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private EnemyMovement _prefab;
    [SerializeField] private Transform _bulletSpawnPos;
    



    private List<EnemyMovement> _bullets;

    public void CreatePool(EnemyMovement prefab, int startCount)
    {
        _bullets = new List<EnemyMovement>();

        for (int i = 0; i < startCount; i++)
        {
            var obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);



            _bullets.Add(obj);
        }
    }



    public EnemyMovement GetFreeElement()
    {
        var obj = _bullets.FirstOrDefault(x => !x.isActiveAndEnabled);

        if (obj)
            obj.gameObject.transform.position = _bulletSpawnPos.position;
        else
            obj = Create();

        obj.gameObject.SetActive(true);
        return obj;
    }



    public void Release(EnemyMovement obj)
    {
        obj.gameObject.SetActive(false);
    }

    public EnemyMovement Create()
    {
        var obj = Instantiate(_prefab);
        _bullets.Add(obj);
        obj.gameObject.transform.position = _bulletSpawnPos.position;
        return obj;
    }

    private void Start()
    {
        CreatePool(_prefab, 10);
    }
}
