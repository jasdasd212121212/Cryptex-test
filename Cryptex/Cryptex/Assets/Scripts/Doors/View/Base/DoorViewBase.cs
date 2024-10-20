using UnityEngine;
using Zenject;

[RequireComponent(typeof(DoorModel))]
public abstract class DoorViewBase : MonoBehaviour
{
    private DoorModel _doorModel;
    
    protected Transform CachedTransform { get; private set; }

    [Inject]
    private void Construct()
    {
        CachedTransform = transform;

        _doorModel = GetComponent<DoorModel>();

        _doorModel.opened += Open;
        _doorModel.closed += Close;
    }

    private void OnDestroy()
    {
        _doorModel.opened -= Open;
        _doorModel.closed -= Close;
    }

    protected abstract void Open();
    protected abstract void Close();
}