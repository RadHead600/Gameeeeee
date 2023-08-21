using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerParameters", menuName = "CustomParameters/SpawnerParameters")]
public class SpawnerParameters : ScriptableObject
{
    [SerializeField] private List<SpawnerObjectParameters> _spawnPrefabs;
    [SerializeField][Min(0)] private int _minCount;
    [SerializeField] private int _maxCount;

    public List<SpawnerObjectParameters> SpawnPrefabs => _spawnPrefabs;
    public int MinCount => _minCount;
    public int MaxCount => _maxCount;
}
