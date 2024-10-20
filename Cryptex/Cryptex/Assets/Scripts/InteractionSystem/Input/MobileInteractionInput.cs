using System;
using UnityEngine.UI;

public class MobileInteractionInput : IInteractionSystemInput
{
    private Button _button;

    public event Action actionButtonPressed;

    public MobileInteractionInput(Button button)
    {
        _button = button;
        _button.onClick.AddListener(OnClick);
    }

    ~MobileInteractionInput()
    {
        if (_button != null)
        {
            _button.onClick.RemoveAllListeners();
        }
    }

    private void OnClick()
    {
        actionButtonPressed?.Invoke();
    }
}