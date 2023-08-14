using UnityEngine;

public class UpgradesParameters : ScriptableObject
{
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;

    public float MinValue => _minValue;
    public float MaxValue => _maxValue;
}
