using UnityEngine;

[CreateAssetMenu(fileName = "LevelParameters", menuName = "CustomParameters/LevelParameters")]
public class LevelParameters : ScriptableObject
{
    [SerializeField][Range(0, 100)] private int _numEnemiesPerLvlPercentage;
    [SerializeField][Min(0)] private int _numEnenmiesOnFirstLvl;
    [SerializeField][Min(0)] private int _numGoldForEnemies;

    public int NumEnemiesPerLvlPercentage => _numEnemiesPerLvlPercentage;
    public int NumEnenmiesOnFirstLvl => _numEnenmiesOnFirstLvl;
    public int NumGoldForEnemies => _numGoldForEnemies;
}
