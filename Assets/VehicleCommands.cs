using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCommands : MonoBehaviour
{
    [SerializeField] Motor motor;

    Vector3 initialPosition;
    Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        if (Input.GetKey("joystick 1 button 0") || Input.GetKey(KeyCode.Z))
            motor.Accelerate();
        else if (Input.GetKey("joystick 1 button 3") || Input.GetKey(KeyCode.V))
            motor.Recede();
        else
            motor.EndTraction();

        if (Input.GetKey("joystick 1 button 1") || Input.GetKey(KeyCode.X))
            motor.Brake();
        else
            motor.EndBrake();

        if (Input.GetKey("joystick 1 button 2") || Input.GetKey(KeyCode.C))
        {
            ResetPosition();
        }

        motor.Steer(Input.GetAxis("Horizontal"));
    }

    void ResetPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
