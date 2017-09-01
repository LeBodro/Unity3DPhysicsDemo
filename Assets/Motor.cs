using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public enum Direction
    {
        LEFT,
        RIGHT,
        STRAIGHT
    }

    [SerializeField] WheelCollider[] wheels;
    [SerializeField] float power = 20f;
    [SerializeField] float steering = 30f;
    [SerializeField] float brake = 2f;

    public void Steer(Direction direction)
    {
        switch (direction)
        {
            case Direction.STRAIGHT:
                Steer(0f);
                break;
            case Direction.LEFT:
                Steer(-steering);
                break;
            case Direction.RIGHT:
                Steer(steering);
                break;
            default:
                break;
        }
    }

    void Steer(float angle)
    {
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
