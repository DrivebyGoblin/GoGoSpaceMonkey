using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private List<Enemy> _allEnemies;
    [SerializeField] private WeaponImprove _weaponImprove;
    [SerializeField] private Transform _rightBound;
    [SerializeField] private Player _player;
    


    public int killedEnemies { get; private set; }

    public List<Enemy> AllEnemies { get => _allEnemies; }

    private List<Vector3> enemyPosition;


    int noActiveEnemies = 0;


    private void Start()
    {
        SavePositions();
        ResetRow();              
    }

    public List<Vector3> SavePositions()
    {
        enemyPosition = new List<Vector3>();

        for (int i = 0; i < _allEnemies.Count; i++)
        {
            var position = _allEnemies[i].transform.localPosition;

            enemyPosition.Add(position);
        }
        return enemyPosition;
    }

    private void OnDisable()
    {

        EnemyDeath.onEnemyKilled -= KilledIncrease;
    }

    private void OnEnable()
    {
        EnemyDeath.onEnemyKilled += KilledIncrease;
    }


    private void ResetValue()
    {
        killedEnemies = 0;
    }

    private void ResetRow()
    {
        var value = UnityEngine.Random.Range(0, _spawnPositions.Length);

        transform.position = _spawnPositions[value].position;

        for (int i = 0; i < _allEnemies.Count; i++)
        {
            _allEnemies[i].transform.localPosition = enemyPosition[i];
            _allEnemies[i].gameObject.SetActive(true);
        }

        ResetValue();

        print(killedEnemies);
    }



    private void ChekEnemies()
    {
        bool hasActiveElements = false;
        foreach (var item in _allEnemies)
        {
            if (item.isActiveAndEnabled)
            {
                hasActiveElements = true;
                break;
            }
        }

        if (!hasActiveElements)
        {
            ResetRow();
        }
    }


    public void KilledIncrease()
    {
        killedEnemies++;
    }

    public void DropImprover()
    {
        if (killedEnemies == _allEnemies.Count)
        {
            _weaponImprove.SpawnImprover();
            ResetRow();
        }
    }

    private void Update()
    {
        DropImprover();
        ChekEnemies();
        //print(killedEnemies);       
    }
}
