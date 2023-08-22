using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerEnemiesParameters", menuName = "CustomParameters/SpawnerParameters/SpawnerEnemiesParameters")]
public class SpawnerEnemiesParameters : SpawnerParameters
{
    [Header("The starting value of the waves at the level of.")]
    [SerializeField][Min(0)] private int _minWaves;
    [Header("The number of completed levels to add a wave.")]
    [SerializeField][Min(0)] private int _numLevelForAddWaves;
    [Header("How many percent increases the number of enemies in the wave at the next level.")]
    [SerializeField][Min(0)] private int _increaseEnemies;

    public int MinWaves => _minWaves;
    public int NumLevelForAddWaves => _numLevelForAddWaves;
    public int IncreaseEnemies => _increaseEnemies;
}
