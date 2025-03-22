using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private IInteractable _interactable;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _point;

    private void OnEnable()
    {
        _interactable.InteractivityOccurred += Spawn;
    }

    private void OnDisable()
    {
        _interactable.InteractivityOccurred -= Spawn;
    }

    public void Spawn()
    {
        Instantiate(_prefab, _point.transform.position, Quaternion.identity);
    }
}
