using System;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public event Action InteractivityOccurred;

    public void Interact()
    {
        InteractivityOccurred?.Invoke();
    }
}
