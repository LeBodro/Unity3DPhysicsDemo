using UnityEngine;

public class PlatformColliderMover : MonoBehaviour
{
    [SerializeField] float rotationPerSecond = 5f;

    void FixedUpdate()
    {
        var frameRotation = rotationPerSecond * Time.fixedDeltaTime;
        Transformation movement = new Rotation(Vector3.up, frameRotation * Mathf.Deg2Rad);

        transform.position = movement.ApplyTo(transform.position);
        transform.eulerAngles -= frameRotation * Vector3.up;
    }
}
