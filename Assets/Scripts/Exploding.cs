using UnityEngine;


public class Exploding : MonoBehaviour, IInteractable
{
    [SerializeField] private float _currentPercentDivision = 100;
    [SerializeField] private float _explosionRadius = 2;
    [SerializeField] private float _explosionForce = 10;


    public void Interact()
    {
        Explode();
    }

    public void Reducing()
    {
        transform.localScale = transform.localScale / _reducingScale;

        _currentPercentDivision = _currentPercentDivision / _reducingChance;
    }
}
