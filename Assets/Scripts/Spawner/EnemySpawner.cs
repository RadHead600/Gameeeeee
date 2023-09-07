using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private int _objectsCount;
    private int _wavesToPassed;
    private float _enemiesReloadingTime;

    public int ObjectsCount => _objectsCount;
    public int WavesToPassed => _wavesToPassed;
    public float EnemiesReloadingTime => _enemiesReloadingTime;

    public override void StartSpawner()
    {
        _enemiesReloadingTime = SpawnerParameters.MaxReloadingTime - Mathf.Pow(GameInformation.Instance.Information.PassedLevel, SpawnerParameters.ReduceReloadingTime);

        int preferredRechargeEmergence = 1;

        int preferredNumberEnemies = 100;
        
        if (_enemiesReloadingTime < SpawnerParameters.MinReloadingTime)
            _enemiesReloadingTime = SpawnerParameters.MinReloadingTime;
        if (_spawnerCoroutine == null)
            _spawnerCoroutine = StartCoroutine(StartEnemiesSpawner((SpawnerEnemiesParameters)SpawnerParameters, _enemiesReloadingTime, preferredRechargeEmergence));
    }

    private IEnumerator StartEnemiesSpawner(SpawnerEnemiesParameters parameters, float reloadingTime, int countWaves)
    {
        _objectsCount = parameters.MinCountObjects + (int)((float)parameters.MinCountObjects * ((float)parameters.IncreaseEnemies / preferredNumberEnemies));
        
        if (_objectsCount > parameters.MaxCountObjects)
            _objectsCount = parameters.MaxCountObjects;
        CreateObjects(_objectsCount, reloadingTime);
        _wavesToPassed = parameters.MinWaves + (int)((float)GameInformation.Instance.Information.PassedLevel / (float)parameters.NumLevelForAddWaves);
        
        if (countWaves >= _wavesToPassed)
        {
            _spawnerCoroutine = null;
            yield break;
        }
        yield return new WaitForSeconds(reloadingTime);
        _spawnerCoroutine = StartCoroutine(StartEnemiesSpawner(parameters, reloadingTime, ++countWaves));
    }
}
