using UnityEngine;

[CreateAssetMenu(fileName = "Mover settings", menuName = "Game design/Player/Mover")]
public class PlayerMoveSettings : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}