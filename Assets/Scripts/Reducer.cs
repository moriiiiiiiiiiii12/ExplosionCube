using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reducer : MonoBehaviour
{
    [SerializeField] private float _reducingScale = 2;

    public void Reducing()
    {
        transform.localScale = transform.localScale / _reducingScale;
    }
}
