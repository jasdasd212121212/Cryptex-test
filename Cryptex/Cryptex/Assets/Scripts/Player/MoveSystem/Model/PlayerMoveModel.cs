using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerMoveModel : MonoBehaviour
{
    [SerializeField] private PlayerMoveSettings _settings;

    private Rigidbody _rigidbody;

    private Vector3 _inputVector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.MovePosition(_rigidbody.position - _inputVector * _settings.Speed * Time.deltaTime);
    }

    public void SetInputVector(Vector2 input)
    {
        Vector2 raw = input.normalized;

        _inputVector = new Vector3(raw.x, 0, raw.y);
    }
}