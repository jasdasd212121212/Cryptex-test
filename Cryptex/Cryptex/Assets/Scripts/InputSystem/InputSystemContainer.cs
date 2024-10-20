using System;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemContainer
{
    private Dictionary<Type, IInputSystem> _inputSystems = new Dictionary<Type, IInputSystem>();

    public void Bind(IInputSystem inputSystem)
    {
        if (ContainsSystem(inputSystem) == true)
        {
            Debug.LogError($"Critical error -> inputSystem: {inputSystem} already been adden");
            return;
        }

        _inputSystems.Add(inputSystem.GetType(), inputSystem);
    }

    public IInputSystem GetSystem(Type systemType)
    {
        foreach (KeyValuePair<Type, IInputSystem> pair in _inputSystems)
        {
            if (pair.Key == systemType || systemType.IsAssignableFrom(pair.Key))
            {
                return pair.Value;
            }
        }

        Debug.LogError($"Critical erro -> inputSystem by Type: {systemType} are not exist now!");
        return null;
    }

    private bool ContainsSystem(IInputSystem system) => _inputSystems.ContainsValue(system);
}