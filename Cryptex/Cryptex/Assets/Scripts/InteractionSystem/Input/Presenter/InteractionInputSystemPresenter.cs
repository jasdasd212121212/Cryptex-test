using UnityEngine;

[RequireComponent(typeof(InteractionSystemModel))]
public class InteractionInputSystemPresenter : InputSystemPresenterBase<IInteractionSystemInput>
{
    private InteractionSystemModel _interactionSystemModel;

    protected override void OnConstruct()
    {
        _interactionSystemModel = GetComponent<InteractionSystemModel>();
        InputSystem.actionButtonPressed += OnPress;
    }

    private void OnDestroy()
    {
        InputSystem.actionButtonPressed -= OnPress;
    }

    private void OnPress()
    {
        _interactionSystemModel.Interact();
    }
}