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

    public void Cut(GameObject target)
    {
        if (!target.TryGetComponent(out Cube cube))
        {
            Destroy(target);
            
            return;
        }

        if (cube.TryConsumeDivision())
        {
            _reducer.Reducing(target.transform);

            int spawnCount = Random.Range(_minCountObjects, _maxCountObjects);
            Vector3 childScale = target.transform.localScale;

            float childChance = cube.CurrentChance;
            float reducingFact = cube.ReducingFactor;

            for (int i = 0; i < spawnCount; i++)
            {
                Rigidbody rigidbody = _spawner.Spawn(target.transform.position);
                rigidbody.transform.localScale = childScale;

                Cube childCube;

                if (rigidbody.TryGetComponent<Cube>(out childCube))
                {
                    childCube.Init(childChance, reducingFact);
                }

                Renderer rendererCube;

                if (rigidbody.TryGetComponent<Renderer>(out rendererCube))
                {
                    _colorer.ChangeColor(rendererCube);
                }

                _explosion.Execute(rigidbody, transform.position);
            }
        }

        Destroy(target);
    }
}
