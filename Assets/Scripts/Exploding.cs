using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        Debug.Log($"{_currentPercentDivision} {randomValue}");

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

        Renderer renderer = newObject.GetComponent<Renderer>();
        renderer.material.color = Utils.GenerateRandomColor();

        newObject.transform.localScale = newObject.transform.localScale / _reducingScale;

        Exploding exploding = newObject.GetComponent<Exploding>();
        exploding._currentPercentDivision = exploding._currentPercentDivision / _reducingChance;

        return newObject;
    }
}
