using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Cutter : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody; 
    
    [SerializeField] private float _reducingChance = 2;
    [SerializeField] private float _reducingScale = 2;
    [SerializeField] private int _minCountObjects = 2; 
    [SerializeField] private int _maxCountObjects = 6;
    
    private float _fullPercentDivision = 100;
    
    private void Start()
    {
        
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
}
