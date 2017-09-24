using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{

    [SerializeField] WheelCollider[] wheels;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float maxRPM = 2000f;
    [SerializeField] float maxSteering = 30f;
    [SerializeField] float brake = 80f;

    public void Steer(float direction)
    {
        var angle = maxSteering * direction;
        ForEachWheel((wheel) => wheel.steerAngle = angle);
    }

    public void Accelerate()
    {
        ForEachWheel((wheel) =>
            {
                if (wheel.motorTorque < maxRPM)
                    wheel.motorTorque = Mathf.Max(wheel.motorTorque + acceleration, acceleration);
            });
    }

    public void EndTraction()
    {
        ForEachWheel((wheel) => wheel.motorTorque = 0);
    }

    public void Recede()
    {
        ForEachWheel((wheel) =>
            {
                if (wheel.motorTorque > -maxRPM)
                    wheel.motorTorque = Mathf.Min(wheel.motorTorque - acceleration, -acceleration);
            });
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
