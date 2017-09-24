using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : Transformation
{
    Vector3 axis;
    float angle;
    float x;
    float y;
    float z;
    float cos;
    float sin;

    public Rotation(Vector3 axis, float angle)
    {
        this.axis = axis.normalized;
        this.angle = angle;
        SimplifyValues();
        SetupMatrix();

    }

    void SimplifyValues()
    {
        x = axis.x;
        y = axis.y;
        z = axis.z;
        cos = Mathf.Cos(angle);
        sin = Mathf.Sin(angle);
    }

    void SetupMatrix()
    {
        transformationMatrix = new Matrix3x3(new float[]
            {
                Mathf.Pow(x, 2) * (1 - cos) + cos, x * y * (1 - cos) - z * sin, x * z * (1 - cos) + y * sin,
                y * x * (1 - cos) + z * sin, Mathf.Pow(y, 2) * (1 - cos) + cos, y * z * (1 - cos) - x * sin,
                z * x * (1 - cos) - y * sin, z * y * (1 - cos) + x * sin, Mathf.Pow(z, 2) * (1 - cos) + cos
            });
    }
}
