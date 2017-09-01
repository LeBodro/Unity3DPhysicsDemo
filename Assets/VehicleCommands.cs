using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCommands : MonoBehaviour
{
    [SerializeField] Motor motor;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            motor.Accelerate();
        }
        else
        {
            motor.Brake();
        }

        if (Input.GetKeyDown(KeyCode.A))
            motor.Steer(Motor.Direction.LEFT);
        else if (Input.GetKeyDown(KeyCode.D))
            motor.Steer(Motor.Direction.RIGHT);
        else if (Input.GetKeyDown(KeyCode.W))
            motor.Steer(Motor.Direction.STRAIGHT);
    }
}
