using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToWheel : MonoBehaviour
{
    WheelCollider wheel;

    void Start()
    {
        wheel = GetComponentInParent<WheelCollider>();
    }

    void Update()
    {
        Vector3 pos;
        Quaternion rot;
        wheel.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}
