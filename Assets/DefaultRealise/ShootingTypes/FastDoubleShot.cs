using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastDoubleShot : ShotSystem
{
    public FastDoubleShot() : base(1, new List<Vector3>() { new Vector3(1f, -0.11f, 0f), new Vector3(1f, 0.11f, 0) }, 100)
    {
        _bulletDirections.Add(_bulletDirections[1]);
    }

}
