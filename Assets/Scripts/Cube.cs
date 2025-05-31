using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [Header("Необходимые компоненты")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Renderer _renderer;

    [Header("Настройки деления")]
    [SerializeField] private float _divisionChance = 100f;
    [SerializeField] private float _reducingFactor = 2f;

    public Rigidbody Rigidbody => _rigidbody;
    public Renderer Renderer => _renderer;
    public float CurrentChance => _divisionChance;
    public float ReducingFactor => _reducingFactor;

    public bool TryConsumeDivision()
    {
        float minDivisionChance = 0f;
        float maxDivisionChance = 100f;

        if (Random.Range(minDivisionChance, maxDivisionChance) < _divisionChance)
        {
            _divisionChance /= _reducingFactor;
            
            return true;
        }

        return false;
    }

    public void Init(float chance, float factor)
    {
        _divisionChance = chance;
        _reducingFactor = factor;
    }
}