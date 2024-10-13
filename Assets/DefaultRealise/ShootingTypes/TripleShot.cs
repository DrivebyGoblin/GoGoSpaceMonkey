using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : ShotSystem
{
    public TripleShot() : base(1, new List<Vector3>() { new Vector3(1f, -0.11f, 0f), new Vector3(1f, 0.11f, 0), new Vector3(1f, 0f, 0f) }, 300)
    {
        _bulletDirections.Add(_bulletDirections[2]);
    }

}
