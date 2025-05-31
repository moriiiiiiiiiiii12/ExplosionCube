using UnityEngine;
using System.Collections.Generic;

public class Exploder : MonoBehaviour
{
    [Header("При делении")]
    [SerializeField] private float _splitExplosionRadius = 2f;
    [SerializeField] private float _splitExplosionForce = 10f;

    [Header("При исчезании")]
    [SerializeField] private float _disappearExplosionRadius = 10f;
    [SerializeField] private float _disappearExplosionForce = 500f;

    public void Execute(Rigidbody rigidbody, Vector3 explosionCenter)
    {
        rigidbody.AddExplosionForce(_splitExplosionForce, explosionCenter, _splitExplosionRadius);
    }

    public void ExecuteScalable(Vector3 explosionCenter, float scaleObject)
    {
        float newExplosionRadius = _disappearExplosionRadius / scaleObject;
        float newExplosionForce  = _disappearExplosionForce  / scaleObject;

        Collider[] hits = Physics.OverlapSphere(explosionCenter, newExplosionRadius); 

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(newExplosionForce, explosionCenter, newExplosionRadius);
            }
        }
    }
}
