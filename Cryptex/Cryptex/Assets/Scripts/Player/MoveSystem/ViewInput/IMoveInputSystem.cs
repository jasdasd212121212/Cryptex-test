using UnityEngine;

public interface IMoveInputSystem : IInputSystem
{
    Vector2 GetInput();
}