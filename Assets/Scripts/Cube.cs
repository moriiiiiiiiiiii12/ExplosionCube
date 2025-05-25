using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [Header("Необходимые компоненты")]
    [SerializeField] private Renderer _renderer;

    [Header("Настройки деления")]
    [SerializeField] private float _divisionChance = 100f;
    [SerializeField] private float _reducingFactor = 2f;

    public float CurrentChance => _divisionChance;
    public float ReducingFactor => _reducingFactor;

    public bool TryConsumeDivision()
    {
        if (Random.Range(0f, 100f) < _divisionChance)
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

    private void Awake()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}