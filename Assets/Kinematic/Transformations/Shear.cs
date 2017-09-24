using UnityEngine;

public class Shear : Transformation
{
    public Shear(float t, float s)
    {
        transformationMatrix = new Matrix3x3(new float[]
            {
                1, 0, t,
                0, 1, s,
                0, 0, 1
            });
    }
}
