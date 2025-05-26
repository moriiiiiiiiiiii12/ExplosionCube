using UnityEngine;

public class Colorer : MonoBehaviour
{
    public void ChangeColor(Renderer renderer)
    {
        renderer.material.color = Random.ColorHSV();
    }
}
