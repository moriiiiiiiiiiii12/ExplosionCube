using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _point;

    public void Spawn()
    {
        Instantiate(_prefab, _point.position, Quaternion.identity);
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
