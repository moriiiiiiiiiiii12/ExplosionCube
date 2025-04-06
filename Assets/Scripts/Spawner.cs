using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _point;
    
    [field: SerializeField] public int MinCountObjects { get; private set; } = 2;
    [field: SerializeField] public int MaxCountObjects { get; private set; } = 6;

    public void Spawn()
    {
        Instantiate(_prefab, _point.position, Quaternion.identity);
    }
    
    public void SpawnMultipleObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(_prefab, _point.position, Quaternion.identity);
        }
    }
}
