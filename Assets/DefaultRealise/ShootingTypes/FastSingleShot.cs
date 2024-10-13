using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSingleShot : ShotSystem
{
    public FastSingleShot() : base(1, new List<Vector3>() { new Vector3(1f, 0f, 0f) }, 100)
    {
        _bulletDirections.Add(_bulletDirections[0]);
    }
    
}
