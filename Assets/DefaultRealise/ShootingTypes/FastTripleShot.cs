using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTripleShot : ShotSystem
{
    public FastTripleShot() : base(1, new List<Vector3>() { new Vector3(1f, -0.11f, 0f), new Vector3(1f, 0.11f, 0), new Vector3(1f, 0f, 0f) }, 10)
    {
        _bulletDirections.Add(_bulletDirections[2]);
    }
}
