using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Cutter : MonoBehaviour
{
    [SerializeField] private IInteractable _interactable;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Reducer _reducer;
 //   [SerializeField] private Spawner _spawner;

    [SerializeField] private float _reducingChance = 2;

    [SerializeField] private float _currentPercentDivision = 100;
    [SerializeField] private int _minCountObjects = 2; 
    [SerializeField] private int _maxCountObjects = 6;
    [SerializeField] private float _explosionRadius = 2;
    [SerializeField] private float _explosionForce = 10;


    private float _fullPercentDivision = 100;

    private void OnEnable()
    {
        _interactable.InteractivityOccurred += Cut;
    }

    private void OnDisable()
    {
        _interactable.InteractivityOccurred -= Cut;
    }

    public void Cut()
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

        newObject.GetComponent<Reducer>().Reducing();

        _currentPercentDivision = _currentPercentDivision / _reducingChance;

        return newObject;
    }
}
