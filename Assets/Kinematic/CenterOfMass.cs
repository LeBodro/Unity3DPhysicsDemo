using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CenterOfMass : MonoBehaviour
{
    [SerializeField] Vector3 centerOfMass;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }
}
