using UnityEngine;


public class ExplosionObject : MonoBehaviour
{
    [SerializeField] private Cutter _cutter;
    [SerializeField] private Explosion _explosion;
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
