using System;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : Singleton<StartGameController>
{
    [SerializeField] private List<Shop> _shops;
    [SerializeField] private List<EnemySpawner> _enemySpawners;
    [SerializeField] private List<Spawner> _spawners;
    [SerializeField] private PointsTimer _pointsTimer;
    [SerializeField] private MoveTo _startTerrain;

    public event Action OnStartGame;

    private void Start()
    {
        SetPlayerParams();
        _startTerrain.DisableScript();
        OnStartGame += _startTerrain.EnableScript;
    }

    private void SetPlayerParams()
    {
        SaveParameters.SkinsBought = new List<int>
        {
            0, 3
        };
        _shops[1].UnlockItems(SaveParameters.SkinsBought);
        _shops[1].Equip(SaveParameters.SkinEquip);

        SaveParameters.WeaponsBought = new List<int>
        {
            0
        };
        _shops[0].UnlockItems(SaveParameters.WeaponsBought);
        _shops[0].Equip(SaveParameters.WeaponEquip);

        SaveParameters.Golds = 100000;
        SaveParameters.Gems = 100000;
        SaveParameters.UpgradePoints = 4;
    }

    public void StartLevel()
    {
        int countKillsOnLevel = 0;
        float time = 0;
        foreach (var spawner in _spawners)
            spawner.StartSpawner();

        foreach (var enemySpawner in _enemySpawners)
            enemySpawner.StartSpawner();

        foreach (var enemySpawner in _enemySpawners)
        {
            SpawnerEnemiesParameters spawnerParameters = (SpawnerEnemiesParameters)enemySpawner.SpawnerParameters;
            countKillsOnLevel = enemySpawner.ObjectsCount * enemySpawner.WavesToPassed;
            time = (spawnerParameters.TimeToKillInSeconds * countKillsOnLevel + (enemySpawner.WavesToPassed * enemySpawner.EnemiesReloadingTime + 1)) * spawnerParameters.AdditionalTime;
        }
        LevelProgress.Instance.RequiredNumberOfKills = countKillsOnLevel;
        if (_pointsTimer != null)
            _pointsTimer.StartTimer(time);

        OnStartGame?.Invoke();
    }

    private void OnDestroy()
    {
        OnStartGame -= _startTerrain.EnableScript;
    }
}
