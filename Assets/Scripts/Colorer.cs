using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class Colorer : MonoBehaviour
{
    [SerializeField] private IInteractable _interactable;
    [SerializeField] private Renderer _renderer;

    private void OnEnable()
    {
        _interactable.InteractivityOccurred += RandomChangeColor;
    }

    private void OnDisable()
    {
        _interactable.InteractivityOccurred -= RandomChangeColor;
    }

    public void RandomChangeColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
