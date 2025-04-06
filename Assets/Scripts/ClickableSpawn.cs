using UnityEngine;
using System;

public class Clickable : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    public void OnMouseDown()
    {
        _spawner.Spawn();
    }
}