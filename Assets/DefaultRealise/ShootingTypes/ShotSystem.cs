using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ShotSystem
{
    protected const float _bulletSpeed = 7f;
    protected int _delayMilliseconds;
    protected bool _canShot = true;
    protected List<Vector3> _bulletDirections;

    

    protected ShotSystem(int directionsCount, List<Vector3> _directions, int delay)
    {
        _delayMilliseconds = delay;
        _bulletDirections = new List<Vector3>(directionsCount);

        for (int i = 0; i < _directions.Count; i++)
        {
            _bulletDirections.Add(_directions[i]);
        }    
    }

    private async void CanShotTrue()
    {
        await Task.Delay(_delayMilliseconds);
        _canShot = true;
    }


    public void Shoot(BulletsPool pool)
    {
        if (_canShot)
        {
            for (int i = 0; i < _bulletDirections.Count - 1; i++)
            {
                var bullet = pool.GetFreeElement();
                bullet.BulletMovement(_bulletDirections[i], _bulletSpeed);
            }

            _canShot = false;
            CanShotTrue();

        }
        else
        {
            return;
        }

        
    }
}
