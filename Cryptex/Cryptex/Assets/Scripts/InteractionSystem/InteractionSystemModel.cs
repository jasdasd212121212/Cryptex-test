using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class InteractionSystemModel : MonoBehaviour
{
    [SerializeField] private LayerMask _intertactionLayers;
    [SerializeField] private Transform _interactionOrigin;
    [SerializeField] private float _interactionRadius;

    private const float SCAN_LOOP_DELAY = 0.3f;

    public event Action<string> interactableFinded;
    public event Action interactebleNotFinded;

    private void Awake()
    {
        ScanLoop().Forget();
    }

    public void Interact()
    {
        FindNearestInterateble(FindAllInteractebles())?.Interact();
    }

    private async UniTask ScanLoop()
    {
        while (true)
        {
            IInteracteble[] interatables = FindAllInteractebles();

            if (interatables != null && interatables.Length > 0)
            {
                interactableFinded?.Invoke(FindNearestInterateble(interatables).ActionName);
            }
            else
            {
                interactebleNotFinded?.Invoke();
            }

            await UniTask.WaitForSeconds(SCAN_LOOP_DELAY);
        }
    }

    private IInteracteble FindNearestInterateble(IInteracteble[] interactebles)
    {
        if (interactebles == null || interactebles.Length == 0)
        {
            return null;
        }

        float currentDistance = float.MaxValue;
        int currentNearestIndex = 0;

        for (int i = 0; i < interactebles.Length; i++)
        {
            float distance = Vector3.Distance(_interactionOrigin.position, interactebles[i].Position);

            if (distance < currentDistance)
            {
                currentNearestIndex = i;
                currentDistance = distance;
            }
        }

        return interactebles[currentNearestIndex];
    }

    private IInteracteble[] FindAllInteractebles()
    {
        Collider[] objects = Physics.OverlapSphere(_interactionOrigin.position, _interactionRadius, _intertactionLayers);
        IInteracteble[] systems = new IInteracteble[objects.Length];

        for (int i = 0; i < systems.Length; i++)
        {
            systems[i] = objects[i].gameObject.GetComponent<IInteracteble>();
        }

        return systems;
    }
}