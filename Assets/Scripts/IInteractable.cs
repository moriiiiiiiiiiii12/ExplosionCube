
using System;

public interface IInteractable
{
    public event Action InteractivityOccurred;

    public void Interact();
}
