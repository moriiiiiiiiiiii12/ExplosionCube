using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class Colorer : MonoBehaviour
{
    public void RandomChangeColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Random.color;
    }
}
