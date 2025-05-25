using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _cubePrefab;
    [SerializeField] private Transform _point;

    public Rigidbody Spawn()
    {
        Rigidbody rigidbody = Instantiate(_cubePrefab, _point.position, Quaternion.identity);

        return rigidbody;
    }

    public Rigidbody Spawn(Vector3 position)
    {
        Rigidbody rigidbody = Instantiate(_cubePrefab, position, Quaternion.identity);
        
        return rigidbody;
    }
}
