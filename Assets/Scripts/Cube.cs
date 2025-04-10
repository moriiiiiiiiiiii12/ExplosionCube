using UnityEngine;


public class Cube : MonoBehaviour
{
    [SerializeField] private Cutter _cutter;
    [SerializeField] private Colorer _colorer;
    [SerializeField] private Reducer _reducer;

    private void Awake()
    {
        _colorer.RandomChangeColor();
    }

    public void Interact()
    {
        _reducer.Reducing();

        _cutter.Cut();
    }
}
