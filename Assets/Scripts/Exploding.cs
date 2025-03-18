using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Exploding : MonoBehaviour, IInteractable
{
    [SerializeField] private float _currentPercentDivision = 100;
    [SerializeField] private float _reducingChance = 2;
    [SerializeField] private float _reducingScale = 2;

    [Header("Настройки разделения")]
    [SerializeField] private int _minCountObjects = 2; 
    [SerializeField] private int _maxCountObjects = 6;

    [Header("Настройки взрыва")]
    [SerializeField] private float _explosionRadius = 2;
    [SerializeField] private float _explosionForce = 10;

    private float _fullPercentDivision = 100;

    public void Interact()
    {
        Explode();
    }

    public void Explode()
    {
        Destroy(gameObject);

        float randomValue = Random.Range(0, _fullPercentDivision);

        if (randomValue < _currentPercentDivision)
        {
            int countObjects = Random.Range(_minCountObjects, _maxCountObjects);

            for (int i = 0; i < countObjects; i++)
            {
                CreateObject().GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }

    private GameObject CreateObject()
    {
        GameObject newObject = Instantiate(gameObject, transform.position, Quaternion.identity);

        Exploding component = newObject.GetComponent<Exploding>();

        component.Reducing();
        component.RandomChangeColor();

        return newObject;
    }

    public void Reducing()
    {
        transform.localScale = transform.localScale / _reducingScale;

        _currentPercentDivision = _currentPercentDivision / _reducingChance;
    }

    public void RandomChangeColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Utils.GenerateRandomColor();
    }
}
