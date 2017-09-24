using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation
{
    protected Matrix3x3 transformationMatrix;

    public Vector3 ApplyTo(Vector3 v)
    {
        return new Vector3(
            CalculateRow(0, v),
            CalculateRow(1, v),
            CalculateRow(2, v)
        );
    }

    float CalculateRow(int row, Vector3 v)
    {
        return transformationMatrix.GetCell(0, row) * v.x + transformationMatrix.GetCell(1, row) * v.y + transformationMatrix.GetCell(2, row) * v.z;
    }
}
