using System;

public interface IInteractionSystemInput : IInputSystem
{
    event Action actionButtonPressed;
}