using UnityEngine;

public class Resize : Transformation
{
    Vector3 newSizeRatio;

    public Resize(Vector3 newSizeRatio)
    {
        this.newSizeRatio = newSizeRatio;
        SetupMatrix();
    }

    void SetupMatrix()
    {
        transformationMatrix = new Matrix3x3(new float[]
            {
                newSizeRatio.x, 0, 0,
                0, newSizeRatio.y, 0,
                0, 0, newSizeRatio.z
            });
    }
}
