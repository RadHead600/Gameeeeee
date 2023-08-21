using System;
using UnityEngine;

[Serializable]
public class SpawnerObjectParameters
{
    [SerializeField] private GameObject _spawnPrefab;
    [SerializeField][Range(0, 100)] private float _chance;

    public GameObject SpawnPrefab => _spawnPrefab;
    public float Chance => _chance;
}
