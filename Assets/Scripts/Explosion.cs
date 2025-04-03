using UnityEngine;


public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _explosionForce = 10f;

    public void Execute(Rigidbody rigidbody, Vector3 explosionCenter)
    {
        rigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
    }
}
