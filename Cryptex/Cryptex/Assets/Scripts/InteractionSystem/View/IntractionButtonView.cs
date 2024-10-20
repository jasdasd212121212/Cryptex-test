using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class IntractionButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [Inject] private InteractionSystemModel _model;

    private void Awake()
    {
        _model.interactableFinded += OnDetect;
        _model.interactebleNotFinded += OnFinded;

        OnFinded();
    }

    private void OnDestroy()
    {
        _model.interactableFinded -= OnDetect;
        _model.interactebleNotFinded -= OnFinded;
    }

    private void OnDetect(string name)
    {
        _button.gameObject.SetActive(true);
    }

    private void OnFinded()
    {
        _button.gameObject.SetActive(false);
    }
}