using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{

    [SerializeField] WheelCollider[] wheels;
    [SerializeField] float power = 20f;
    [SerializeField] float steering = 30f;
    [SerializeField] float brake = 2f;

    public void Steer(float direction)
    {
        var angle = steering * direction;
        ForEachWheel((wheel) => wheel.steerAngle = angle);
    }

    public void Accelerate()
    {
        ForEachWheel((wheel) => wheel.motorTorque = Mathf.Max(wheel.motorTorque + power, power));
    }

    public void EndTraction()
    {
        ForEachWheel((wheel) => wheel.motorTorque = 0);
    }

    public void Recede()
    {
        ForEachWheel((wheel) => wheel.motorTorque = Mathf.Min(wheel.motorTorque - power, -power));
    }

    public void Brake()
    {
        ForEachWheel((wheel) => wheel.brakeTorque += brake);
    }

    public void EndBrake()
    {
        ForEachWheel((wheel) => wheel.brakeTorque = 0);
    }

    void ForEachWheel(System.Action<WheelCollider> doThis)
    {
        foreach (var wheel in wheels)
        {
            doThis(wheel);
        }
    }
}
