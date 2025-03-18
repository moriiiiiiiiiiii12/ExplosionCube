using UnityEngine;

public class Spawner : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _point;
    [SerializeField] private GameObject _prefab;

    public void Interact()
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(_prefab, _point.transform.position, Quaternion.identity);
    }
}
