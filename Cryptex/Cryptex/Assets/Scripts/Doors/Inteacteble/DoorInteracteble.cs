using UnityEngine;

[RequireComponent(typeof(DoorModel))]
public class DoorInteracteble : MonoBehaviour, IInteracteble
{
    private DoorModel _model;
    private Transform _cachedTransform;

    public string ActionName => _model.CurrentState == DoorModel.DoorState.Opened ? "close" : "open";
    public Vector3 Position => _cachedTransform.position;

    private void Awake()
    {
        _model = GetComponent<DoorModel>();
        _cachedTransform = transform;
    }

    public void Interact()
    {
        _model.Interact();
    }
}