using UnityEngine;

public class JoystickInputSystem : IMoveInputSystem
{
    private Joystick _joystick;

    public JoystickInputSystem(Joystick joystick)
    {
        _joystick = joystick;
    }

    public Vector2 GetInput()
    {
        return new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }
}