using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 10;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxDistance))
            {
                Transform objectHit = hit.transform;

                IInteractable explodingComponent = objectHit.GetComponent<IInteractable>();

                if (explodingComponent != null)
                {
                    explodingComponent.Interact(); 
                }
            }
        }
    }
}
