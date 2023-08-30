using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "CustomParameters/PlayerParameters")]
public class PlayerParameters : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _minHealthPoints;
    [Header("waiting time before restarting the death scene")]
    [SerializeField] private float _timeBeforRestartScene;

    public float Speed => _speed;
    public int MinHealthPoints => _minHealthPoints;
    public float TimeBeforRestartScene => _timeBeforRestartScene;
}
