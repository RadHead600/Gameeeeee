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
        if (GameInformation.Instance.SkinsBought.Count == 0)
        {
            GameInformation.Instance.SkinsBought = new List<int>
            {
                0
            };
        }
        _shops[1].UnlockItems(GameInformation.Instance.SkinsBought);
        _shops[1].Equip(GameInformation.Instance.SkinEquip);

        if (GameInformation.Instance.WeaponsBought.Count == 0)
        {
            GameInformation.Instance.WeaponsBought = new List<int>
            {
                0
            };
        }
        _shops[0].UnlockItems(GameInformation.Instance.WeaponsBought);
        _shops[0].Equip(GameInformation.Instance.WeaponEquip);
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
