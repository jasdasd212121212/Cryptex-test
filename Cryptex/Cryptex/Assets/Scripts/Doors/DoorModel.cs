using System;
using UnityEngine;

public class DoorModel : MonoBehaviour
{
    private DoorState _currentState;

    public DoorState CurrentState => _currentState;

    public event Action opened;
    public event Action closed;

    private void Awake()
    {
        SetState(DoorState.Closed);
    }

    public void Interact()
    {
        if (_currentState == DoorState.Opened)
        {
            SetState(DoorState.Closed);
        }
        else
        {
            SetState(DoorState.Opened);
        }
    }

    private void SetState(DoorState state)
    {
        _currentState = state;

        if (state == DoorState.Opened)
        {
            opened?.Invoke();
        }
        else if (state == DoorState.Closed)
        {
            closed?.Invoke();
        }
        else
        {
            Debug.LogError($"Critical erro -> undefined door state: {state}");
        }
    }

    public enum DoorState
    {
        Opened,
        Closed
    }
}