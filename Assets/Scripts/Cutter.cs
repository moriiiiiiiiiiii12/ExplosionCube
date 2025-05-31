using UnityEngine;

public class Cutter : MonoBehaviour
{
    [Header("Необходимые компоненты")]
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _explosion;
    [SerializeField] private Reducer _reducer;
    [SerializeField] private Colorer _colorer;

    [Header("Настройки спавна")]
    [SerializeField] private int _minCountObjects = 2; 
    [SerializeField] private int _maxCountObjects = 6;

    public void Cut(Cube targetCube)
    {
        Destroy(targetCube.gameObject);

        if (targetCube.TryConsumeDivision())
        {
            _reducer.Reducing(targetCube.transform);

            int spawnCount = Random.Range(_minCountObjects, _maxCountObjects);
            Vector3 childScale = targetCube.transform.localScale;

            float childChance = targetCube.CurrentChance;
            float reducingFact = targetCube.ReducingFactor;

            for (int i = 0; i < spawnCount; i++)
            {
                Cube newCube = _spawner.Spawn(targetCube.transform.position);
                newCube.transform.localScale = childScale;

                newCube.Init(childChance, reducingFact);
                _colorer.ChangeColor(newCube.Renderer);
                _explosion.Execute(newCube.Rigidbody, transform.position);
            }
        }

        else
        {
            _explosion.ExecuteScalable(targetCube.transform.position, targetCube.transform.localScale.x);
        }
    }
}
