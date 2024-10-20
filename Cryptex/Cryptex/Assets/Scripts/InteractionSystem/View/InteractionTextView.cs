using UnityEngine;
using TMPro;
using Zenject;

public class InteractionTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [Inject] private InteractionSystemModel _model;

    private string _baseText;

    private void Awake()
    {
        _model.interactableFinded += OnDetect;
    }

    private void Start()
    {
        _baseText = _text.text;
    }

    private void OnDestroy()
    {
        _model.interactableFinded -= OnDetect;
    }

    private void OnDetect(string name)
    {
        _text.text = $"{_baseText} {name}";
    }
}