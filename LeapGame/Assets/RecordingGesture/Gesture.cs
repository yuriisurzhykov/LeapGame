using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Gesture
{
    public List<Primitive> PrimitivesLeft { get; set; } = new List<Primitive>();
    public List<Primitive> PrimitivesRight { get; set; } = new List<Primitive>();

    public void Add(Primitive primitiveLeft, Primitive primitiveRight)
    {
        PrimitivesLeft.Add(primitiveLeft);
        PrimitivesRight.Add(primitiveRight);
    }

    public void AddRange(Primitive[] primitivesLeft, Primitive[] primitivesRight)
    {
        PrimitivesLeft.AddRange(primitivesLeft);
        PrimitivesRight.AddRange(primitivesRight);
    }

    public override string ToString()
    {
        return PrimitivesLeft.ToString() + "\n" + PrimitivesRight.ToString();
    }
}
