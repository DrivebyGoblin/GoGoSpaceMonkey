using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : ShotSystem
{

    public SingleShot() : base(1, new List<Vector3>() { new Vector3(1f, 0f, 0f) }, 300)
    {
        _bulletDirections.Add(_bulletDirections[0]);
    }

}
