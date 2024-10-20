using UnityEngine;
using Zenject;

[RequireComponent(typeof(InteractionSystemModel))]
public class InteractionPlayerComponentInstaller : PlayerComponentInstaller
{
    public override void Install(DiContainer container)
    {
        container.Bind<InteractionSystemModel>().FromInstance(GetComponent<InteractionSystemModel>()).AsSingle().Lazy();
    }
}