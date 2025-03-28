using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Clickable _clickable;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _point;

    private void OnEnable()
    {
        _clickable.InteractivityOccurred += Spawn;
    }

    private void OnDisable()
    {
        _clickable.InteractivityOccurred -= Spawn;
    }

    public void Spawn()
    {
        Instantiate(_prefab, _point.transform.position, Quaternion.identity);
    }
}
