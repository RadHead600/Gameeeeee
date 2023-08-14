using UnityEngine;

[CreateAssetMenu(fileName = "UnitParameters", menuName = "CustomParameters/UnitParameters")]
public class UnitParameters : ScriptableObject
{
    [SerializeField] private float _directionTime;
    [SerializeField] private int _minHpWall;

    public float DirectionTime => _directionTime;
    public int MinHpWall => _minHpWall;
}
