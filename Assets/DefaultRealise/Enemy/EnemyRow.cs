using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private List<Enemy> _allEnemies;
    [SerializeField] private WeaponImprove _weaponImprove;
    [SerializeField] private Transform _rightBound;

    private List<Vector3> enemyPosition;
    

    
    

    private void Start()
    {
        //DropImprover();
        SavePositions();
        SetPosition();

        
        
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
    


    public void SetPosition()
    {
        var value = Random.Range(0, _spawnPositions.Length);
        
        transform.position = _spawnPositions[value].position;

        for (int i = 0; i < _allEnemies.Count; i++)
        {
            _allEnemies[i].transform.localPosition = enemyPosition[i];
            _allEnemies[i].gameObject.SetActive(true);
        }
        
    }


    public void DropImprover()
    {
        int killed = 0;
        for (int i = 0; i < _allEnemies.Count; i++)
        {
            if (!_allEnemies[i].gameObject.activeSelf)
            {
                killed++;
            }           
        }
        if (killed == _allEnemies.Count)
        {
            print("Дпноюелусерс");
        }
    }

    private void Update()
    {
        DropImprover();

        if (Input.GetKeyDown(KeyCode.O))
        {
            SetPosition();
        }
    }
}
