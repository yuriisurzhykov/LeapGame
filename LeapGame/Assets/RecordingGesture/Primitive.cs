using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Primitive
{
    List<Vector3> _positions = new List<Vector3>();
    List<Quaternion> _rotations = new List<Quaternion>();


    public void WriteTransform(Transform newTransform)
    {
        _positions.Add(newTransform.position);
        _rotations.Add(newTransform.rotation);
    }
    public void Clear()
    {
        _positions.Clear();
        _rotations.Clear();
    }

    public override string ToString()
    {
        return _positions.ToString() + "\n" + _rotations.ToString();
    }
}
