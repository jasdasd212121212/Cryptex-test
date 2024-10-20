using UnityEngine;
using Zenject;

public abstract class InputSystemPresenterBase<TSystem> : MonoBehaviour where TSystem : IInputSystem
{
    protected TSystem InputSystem { get; private set; }

    [Inject]
    private void Construct(InputSystemContainer container)
    {
        InputSystem = (TSystem)container.GetSystem(typeof(TSystem));
    
        OnConstruct();
    }

    protected virtual void OnConstruct() { }
}