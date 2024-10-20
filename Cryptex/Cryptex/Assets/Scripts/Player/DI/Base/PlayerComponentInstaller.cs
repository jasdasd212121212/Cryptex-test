using UnityEngine;
using Zenject;

public abstract class PlayerComponentInstaller : MonoBehaviour
{
    public abstract void Install(DiContainer container);
}