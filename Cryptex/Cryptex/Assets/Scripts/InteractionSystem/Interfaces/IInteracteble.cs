using UnityEngine;

public interface IInteracteble
{
    string ActionName { get; }
    Vector3 Position { get; }

    void Interact();
}