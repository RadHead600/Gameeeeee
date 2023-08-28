using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesParameters", menuName = "CustomParameters/EnemiesParameters")]
public class EnemiesParameters : ScriptableObject
{
    [SerializeField] private int _minHealth;

    public int MinHealth => _minHealth;
}
