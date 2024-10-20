using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] protected PlayerComponentInstaller[] _componentInstallers;

    public override void InstallBindings()
    {
        foreach (PlayerComponentInstaller componentInstaller in _componentInstallers)
        {
            componentInstaller.Install(Container);
        }
    }
}