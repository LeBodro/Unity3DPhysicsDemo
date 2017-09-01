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
        foreach (var wheel in wheels)
        {
            wheel.steerAngle = angle;
        } 
    }

    public void TurnRight()
    {
        foreach (var wheel in wheels)
        {
            wheel.steerAngle = steering;
        }
    }

    public void Accelerate()
    {
        foreach (var wheel in wheels)
        {
            wheel.brakeTorque = 0;
            wheel.motorTorque += power;
        }
    }

    public void Brake()
    {
        foreach (var wheel in wheels)
        {
            wheel.motorTorque = 0;
            wheel.brakeTorque += brake;
        }
    }
}
