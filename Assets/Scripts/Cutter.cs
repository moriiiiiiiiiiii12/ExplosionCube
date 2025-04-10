using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Cutter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Reducer _reducer;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private float _divisionChance = 100f;
    [SerializeField] private float _reducingFactor = 2f;
    [SerializeField] private int _minCountObjects = 2; 
    [SerializeField] private int _maxCountObjects = 6; 

    public void Cut()
    {
        float minValue = 0f;
        float maxValue = 100f;
        float randomValue = Random.Range(minValue, maxValue);

        int spawnCount = Random.Range(_minCountObjects, _maxCountObjects);

        if (randomValue < _divisionChance)
        {
            _divisionChance /= _reducingFactor;

            for(int i = 0; i < spawnCount; i++) 
            {
                Rigidbody rigid = _spawner.Spawn(transform.position);
                
                _explosion.Execute(rigid, transform.position);
            }
        }

        Destroy(gameObject);
    }
}
