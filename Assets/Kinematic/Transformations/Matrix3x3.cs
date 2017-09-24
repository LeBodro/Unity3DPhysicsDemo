using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix3x3
{
    float[] values;

    public Matrix3x3()
    {
        values = new float[9];
    }

    public Matrix3x3(float[] values)
    {
        this.values = values;
    }

    public float GetCell(int x, int y)
    {
        return values[y + x * 3];
    }
}
