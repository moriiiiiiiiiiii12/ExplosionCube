using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Cutter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Reducer _reducer;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private float _divisionChance = 100f;
    [SerializeField] private float _reducingFactor = 2f;

    public void Cut()
    {
        float randomValue = Random.Range(0f, _divisionChance);

        if (randomValue < _divisionChance)
        {
            int spawnCount = Random.Range(_spawner.MinCountObjects, _spawner.MaxCountObjects);

            _spawner.SpawnMultipleObjects(spawnCount);

            _divisionChance /= _reducingFactor;
        }

        if (_explosion != null && TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            _explosion.Execute(rigidbody, transform.position);
        }
        
        Destroy(gameObject);
    }
}
