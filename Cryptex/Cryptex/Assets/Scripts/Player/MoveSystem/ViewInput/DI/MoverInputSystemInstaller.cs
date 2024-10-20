using UnityEngine;

public class MoverInputSystemInstaller : InputSystemInstaller
{
    [SerializeField] private Joystick _joystick;

    protected override IInputSystem OnInstall()
    {
        return new JoystickInputSystem(_joystick);
    }
}