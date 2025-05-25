using UnityEngine;

public class Reducer : MonoBehaviour
{
    [SerializeField] private float _reducingScale = 2f;

    public void Reducing(Transform transform)
    {
        transform.localScale /= _reducingScale;
    }
}