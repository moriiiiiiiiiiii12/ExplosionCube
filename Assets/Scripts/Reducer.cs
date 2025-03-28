using UnityEngine;

public class Reducer : MonoBehaviour
{
    [SerializeField] private float _reducingScale = 2f;

    public void Reducing()
    {
        transform.localScale /= _reducingScale;
    }
}