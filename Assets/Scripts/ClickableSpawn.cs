using UnityEngine;

public class ClickableSpawn : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    public void OnMouseDown()
    {
        _spawner.Spawn();
    }
}