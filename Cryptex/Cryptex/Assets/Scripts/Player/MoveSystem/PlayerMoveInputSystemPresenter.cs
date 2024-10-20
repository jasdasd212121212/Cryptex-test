using UnityEngine;

[RequireComponent(typeof(PlayerMoveModel))]
public class PlayerMoveInputSystemPresenter : InputSystemPresenterBase<IMoveInputSystem>
{
    private PlayerMoveModel _model;

    protected override void OnConstruct()
    {
        _model = GetComponent<PlayerMoveModel>();
    }

    private void Update()
    {
        _model.SetInputVector(InputSystem.GetInput());
    }
}