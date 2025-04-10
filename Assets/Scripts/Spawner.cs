using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _point;

    public Rigidbody Spawn()
    {
        Rigidbody rigidbody = Instantiate(_prefab, _point.position, Quaternion.identity);
        
        return rigidbody;
    }

    public Rigidbody Spawn(Vector3 position)
    {
        Rigidbody rigidbody = Instantiate(_prefab, position, Quaternion.identity);
        
        return rigidbody;
    }
    
    public List<Rigidbody> SpawnMultipleObjects(int count)
    {
        List<Rigidbody> objects = new List<Rigidbody>();

        for (int i = 0; i < count; i++)
        {
            Rigidbody rigidbodyObject = Instantiate(_prefab, _point.position, Quaternion.identity);

            objects.Add(rigidbodyObject);
        }

        return objects;
    }
}
