using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Colorer : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public void RandomChangeColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
