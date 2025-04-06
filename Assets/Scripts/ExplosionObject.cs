using System;
using UnityEngine;


public class ExplosionObject : MonoBehaviour
{
    [SerializeField] private Cutter _cutter;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Colorer _colorer;
    [SerializeField] private Reducer _reducer;

    public void Interact()
    {
        _reducer.Reducing();

        _colorer.RandomChangeColor();

        _cutter.Cut();
    }
}
