using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public void CreateObjects(int objectCount, List<SpawnerObjectParameters> spawnObjects)
    {
        Vector2 z = new Vector2(_collider.bounds.min.z, _collider.bounds.max.z);
        Vector2 x = new Vector2(_collider.bounds.min.x, _collider.bounds.max.x);
        for (int i = 0; i < objectCount; i++)
        {
            foreach (var spawn in spawnObjects)
            {
                if (Random.Range(0, 100) <= spawn.Chance)
                {
                    Unit spawnObject = Instantiate(spawn.SpawnPrefab);
                    Vector3 newPos = new Vector3(Random.Range(x.x, x.y), transform.position.y, Random.Range(z.x, z.y));
                    if (spawnObject is EnemyAI)
                    {
                        ((EnemyAI)spawnObject).NavMeshAgent.Warp(newPos);
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
