using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCommands : MonoBehaviour
{
    [SerializeField] Motor motor;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetKey("joystick 1 button 0"))
        {
            motor.Accelerate();
        }

        if (Input.GetKey("joystick 1 button 1"))
        {
            motor.Brake();
        }

        if (Input.GetKey("joystick 1 button 2"))
        {
            ResetPosition();
        }

        motor.Steer(Input.GetAxis("Horizontal"));
    }

    void ResetPosition()
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
    }
}
