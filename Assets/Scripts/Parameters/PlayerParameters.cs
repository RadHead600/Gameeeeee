using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "CustomParameters/PlayerParameters")]
public class PlayerParameters : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _minHealthPoints;

    public float Speed => _speed;
    public int MinHealthPoints => _minHealthPoints;
}
