using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private List<Shop> _shops;
    [SerializeField] private SerializeSpawnerParameters _enemySpawner;
    [SerializeField] private List<SerializeSpawnerParameters> _objectsSpawner;

    private Coroutine _enemiesSpawnerCoroutine;
    private int _objectsCount;
    private int _wavesToPassed;

    private void Start()
    {
        SetPlayerParams();
    }

    private void SetPlayerParams()
    {
        SaveParameters.weaponsBought = new bool[_shops[0].ShopParameters.Items.Count];
        SaveParameters.weaponsBought = new bool[_shops[0].ShopParameters.Items.Count];
        SaveParameters.weaponsBought[0] = true;
        _shops[0].UnlockItems(SaveParameters.weaponsBought);
        _shops[0].Equip(0);

        SaveParameters.skinsBought = new bool[_shops[1].ShopParameters.Items.Count];
        SaveParameters.skinsBought = new bool[_shops[1].ShopParameters.Items.Count];
        SaveParameters.skinsBought[0] = true;
        _shops[1].UnlockItems(SaveParameters.skinsBought);
        _shops[1].Equip(0);
        SaveParameters.golds += 100000;
        SaveParameters.gems += 100000;
    }

    public void StartLevel()
    {
        SpawnerEnemiesParameters parameters = (SpawnerEnemiesParameters)_enemySpawner.SpawnerParameters;
        float enemiesReloadingTime = parameters.MaxReloadingTime - (Mathf.Pow(SaveParameters.passedLevel, parameters.ReduceReloadingTime));
        if (enemiesReloadingTime < parameters.MinReloadingTime)
            enemiesReloadingTime = parameters.MinReloadingTime;
        if (_enemiesSpawnerCoroutine == null)
            _enemiesSpawnerCoroutine = StartCoroutine(StartEnemiesSpawner(parameters, enemiesReloadingTime, 1));
        LevelProgressUpdater.Instance.RequiredNumberOfKills = _objectsCount * _wavesToPassed;
    }

    private IEnumerator StartEnemiesSpawner(SpawnerEnemiesParameters parameters, float reloadingTime, int countWaves)
    {
        _objectsCount = parameters.MinCountObjects + (int)((float)parameters.MinCountObjects * (parameters.IncreaseEnemies / 100));
        if (_objectsCount > parameters.MaxCountObjects)
            _objectsCount = parameters.MaxCountObjects;
        _enemySpawner.Spawner.CreateObjects(_objectsCount, parameters.SpawnPrefabs);
        _wavesToPassed = parameters.MinWaves + (int)((float)SaveParameters.passedLevel / (float)parameters.NumLevelForAddWaves);
        if (countWaves >= _wavesToPassed)
        {
            _enemiesSpawnerCoroutine = null;
            yield break;
        }
        yield return new WaitForSeconds(reloadingTime);
        _enemiesSpawnerCoroutine = StartCoroutine(StartEnemiesSpawner(parameters, reloadingTime, ++countWaves));
    }
}
