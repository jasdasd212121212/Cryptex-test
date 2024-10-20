using Zenject;

public abstract class InputSystemInstaller : MonoInstaller
{
    [Inject] private InputSystemContainer _container;

    public override void InstallBindings()
    {
        _container.Bind(OnInstall());
    }

    protected abstract IInputSystem OnInstall();
}