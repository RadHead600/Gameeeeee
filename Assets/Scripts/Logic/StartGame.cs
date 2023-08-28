using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : Singleton<StartGame>
{
    [SerializeField] private List<Shop> _shops;
    [SerializeField] private SerializeSpawnerParameters _enemySpawner;
    [SerializeField] private List<SerializeSpawnerParameters> _objectsSpawner;
    [SerializeField] private UpgradePointsTimer _pointsTimer;

    private Coroutine _enemiesSpawnerCoroutine;
    private int _objectsCount;
    private int _wavesToPassed;

    public event Action OnStartGame;

    private void Start()
    {
        SetPlayerParams();
    }

    private void SetPlayerParams()
    {
        SaveParameters.SkinsBought = new bool[_shops[1].ShopParameters.Items.Count];
        SaveParameters.SkinsBought = new bool[_shops[1].ShopParameters.Items.Count];
        SaveParameters.SkinsBought[0] = true;
        _shops[1].UnlockItems(SaveParameters.SkinsBought);
        _shops[1].Equip(0);

        SaveParameters.WeaponsBought = new bool[_shops[0].ShopParameters.Items.Count];
        SaveParameters.WeaponsBought = new bool[_shops[0].ShopParameters.Items.Count];
        SaveParameters.WeaponsBought[0] = true;
        _shops[0].UnlockItems(SaveParameters.WeaponsBought);
        _shops[0].Equip(0);

        SaveParameters.Golds += 100000;
        SaveParameters.Gems += 100000;
    }

    public void StartLevel()
    {
        SpawnerEnemiesParameters parameters = (SpawnerEnemiesParameters)_enemySpawner.SpawnerParameters;
        float enemiesReloadingTime = parameters.MaxReloadingTime - (Mathf.Pow(SaveParameters.PassedLevel, parameters.ReduceReloadingTime));
        if (enemiesReloadingTime < parameters.MinReloadingTime)
            enemiesReloadingTime = parameters.MinReloadingTime;
        if (_enemiesSpawnerCoroutine == null)
            _enemiesSpawnerCoroutine = StartCoroutine(StartEnemiesSpawner(parameters, enemiesReloadingTime, 1));
        int countKillsOnLevel = _objectsCount * _wavesToPassed;
        LevelProgressUpdater.Instance.RequiredNumberOfKills = countKillsOnLevel;
        if (_pointsTimer != null)
            _pointsTimer.StartTimer((parameters.TimeToKillInSeconds * countKillsOnLevel + (_wavesToPassed * enemiesReloadingTime + 1)) * parameters.AdditionalTime);
        OnStartGame?.Invoke();
    }

    private IEnumerator StartEnemiesSpawner(SpawnerEnemiesParameters parameters, float reloadingTime, int countWaves)
    {
        _objectsCount = parameters.MinCountObjects + (int)((float)parameters.MinCountObjects * ((float)parameters.IncreaseEnemies / 100));
        if (_objectsCount > parameters.MaxCountObjects)
            _objectsCount = parameters.MaxCountObjects;
        _enemySpawner.Spawner.CreateObjects(_objectsCount, parameters.SpawnPrefabs);
        _wavesToPassed = parameters.MinWaves + (int)((float)SaveParameters.PassedLevel / (float)parameters.NumLevelForAddWaves);
        if (countWaves >= _wavesToPassed)
        {
            _enemiesSpawnerCoroutine = null;
            yield break;
        }
        yield return new WaitForSeconds(reloadingTime);
        _enemiesSpawnerCoroutine = StartCoroutine(StartEnemiesSpawner(parameters, reloadingTime, ++countWaves));
    }
}
