using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnerParameters> _spawnerParameters;
    [SerializeField] private float _reloadingTime;

    private void Start()
    {
        StartCoroutine(CreateObjects());
    }

    private IEnumerator CreateObjects()
    {
        yield return new WaitForSeconds(_reloadingTime);
        foreach (var spawn in _spawnerParameters)
            CreateObject(spawn);

        StartCoroutine(CreateObjects());
    }

    private void CreateObject(SpawnerParameters spawnerParameters)
    {
        Vector2 z = new Vector2(gameObject.GetComponent<Collider>().bounds.min.z, gameObject.GetComponent<Collider>().bounds.max.z);
        Vector2 x = new Vector2(gameObject.GetComponent<Collider>().bounds.min.x, gameObject.GetComponent<Collider>().bounds.max.x);
        int objCount = Random.Range(spawnerParameters.MinCount, spawnerParameters.MaxCount);
        for (int i = 0; i < objCount; i++)
        {
            foreach (var spawn in spawnerParameters.SpawnPrefabs)
            {
                if (Random.Range(0, 100) <= spawn.Chance)
                {
                    GameObject spawnObject = Instantiate(spawn.SpawnPrefab);
                    Vector3 newPos = new Vector3(Random.Range(x.x, x.y), transform.position.y, Random.Range(z.x, z.y));
                    if (spawnObject.GetComponent<NavMeshAgent>() != null)
                    {
                        spawnObject.GetComponent<NavMeshAgent>().Warp(newPos);
                    }
                    else
                    {
                        spawnObject.transform.position = newPos;
                    }
                    break;
                }
            }
        }
    }

}
