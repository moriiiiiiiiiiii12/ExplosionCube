using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 10f;

    private void Update()
    {
        int numberButton = 0;

        if (Input.GetMouseButtonDown(numberButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
            {
                if (hit.transform.TryGetComponent(out Clickable clickable))
                {
                    clickable.Interact();
                }
            }
        }
    }
}
