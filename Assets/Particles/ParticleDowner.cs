using UnityEngine;

public class ParticleDowner : MonoBehaviour
{
    [SerializeField] float downBump = 0.1f;

    void OnParticleCollision(GameObject other)
    {
        var newPos = other.transform.position;
        newPos.y -= downBump;
        other.transform.position = newPos;
    }
}
