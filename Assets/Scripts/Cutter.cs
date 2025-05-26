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


        if (targetCube.TryConsumeDivision())
        {
            _reducer.Reducing(targetCube.transform);

            int spawnCount = Random.Range(_minCountObjects, _maxCountObjects);
            Vector3 childScale = targetCube.transform.localScale;

            float childChance = targetCube.CurrentChance;
            float reducingFact = targetCube.ReducingFactor;

            for (int i = 0; i < spawnCount; i++)
            {
                Rigidbody rigidbody = _spawner.Spawn(targetCube.transform.position);
                rigidbody.transform.localScale = childScale;

                if (rigidbody.TryGetComponent<Cube>(out Cube childCube))
                {
                    childCube.Init(childChance, reducingFact);
                }

                if (rigidbody.TryGetComponent<Renderer>(out Renderer rendererCube))
                {
                    _colorer.ChangeColor(rendererCube);
                }

                _explosion.Execute(rigidbody, transform.position);
            }
        }

        Destroy(targetCube);
    }
}
