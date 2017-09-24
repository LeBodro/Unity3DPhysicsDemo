using UnityEngine;

public class PlatformRigidbodyMover : MonoBehaviour
{
    [SerializeField] float rotationPerSecond = -15f;

    Rigidbody ownBody;

    void Start()
    {
        ownBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var frameRotation = rotationPerSecond * Time.fixedDeltaTime;
        Transformation movement = new Rotation(Vector3.up, frameRotation * Mathf.Deg2Rad);

        ownBody.MovePosition(movement.ApplyTo(transform.position));
        ownBody.MoveRotation(Quaternion.Euler(transform.eulerAngles - frameRotation * Vector3.up));
    }
}
