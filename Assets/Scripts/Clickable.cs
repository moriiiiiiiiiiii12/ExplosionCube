using System;
using UnityEngine;

public class Clickable : MonoBehaviour, IInteractable
{
    public event Action InteractivityOccurred;

    public void Interact()
    {
        InteractivityOccurred?.Invoke();
    }
}
