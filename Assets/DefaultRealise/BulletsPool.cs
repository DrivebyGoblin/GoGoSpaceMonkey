using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _bulletSpawnPos;


    

    private List<Bullet> _bullets;

    public void CreatePool(Bullet prefab, int startCount)
    {
        _bullets = new List<Bullet>();

        for (int i = 0; i < startCount; i++)
        {
            var obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);

            

            _bullets.Add(obj);
        }
    }

    private void OnDisable()
    {
        EnemyDeath.onBulletCollided -= Release;
    }

    private void OnEnable()
    {
        EnemyDeath.onBulletCollided += Release;
    }

    public Bullet GetFreeElement()
    {
        var obj = _bullets.FirstOrDefault(x => !x.isActiveAndEnabled);

        if (obj)
            obj.gameObject.transform.position = _bulletSpawnPos.position;
        else
            obj = Create();

        obj.gameObject.SetActive(true);
        return obj;
    }



    public void Release(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    public Bullet Create()
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
