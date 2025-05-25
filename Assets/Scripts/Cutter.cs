using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Cutter : MonoBehaviour
{
    [Header("Необходимые компоненты")]
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Reducer _reducer;

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
                Rigidbody rb = _spawner.Spawn(target.transform.position);
                rb.transform.localScale = childScale;

                Cube childCube = rb.GetComponent<Cube>();
                if (childCube != null)
                {
                    childCube.Init(childChance, reducingFact);
                }

                _explosion.Execute(rb, transform.position);
            }
        }

        Destroy(target);
    }
}
