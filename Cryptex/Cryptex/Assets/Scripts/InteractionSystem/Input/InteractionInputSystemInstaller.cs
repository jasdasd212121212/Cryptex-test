using UnityEngine;
using UnityEngine.UI;

public class InteractionInputSystemInstaller : InputSystemInstaller
{
    [SerializeField] private Button _interactionButton;

    protected override IInputSystem OnInstall()
    {
        return new MobileInteractionInput(_interactionButton);
    }
}