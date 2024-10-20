using Zenject;

public class InputSystemContainerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputSystemContainer>().FromInstance(new InputSystemContainer()).AsSingle().NonLazy();
    }
}