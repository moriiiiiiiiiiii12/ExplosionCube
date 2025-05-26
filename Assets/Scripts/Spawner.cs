using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;  
    [SerializeField] private Transform _point;  

    public Cube Spawn()
    {
        return Instantiate(_cubePrefab, _point.position, Quaternion.identity);
    }

    public Cube Spawn(Vector3 position)
    {
        return Instantiate(_cubePrefab, position, Quaternion.identity);
    }
}