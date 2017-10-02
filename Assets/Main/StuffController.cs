using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StuffController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody ownBody;

    void Start()
    {
        ownBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(h, v, 0).normalized * speed * Time.fixedDeltaTime;
        ownBody.MovePosition(transform.position + velocity);
    }
}
