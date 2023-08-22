using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public void CreateObjects(int objectCount, List<SpawnerObjectParameters> spawnObjects)
    {
        Vector2 z = new Vector2(gameObject.GetComponent<Collider>().bounds.min.z, gameObject.GetComponent<Collider>().bounds.max.z);
        Vector2 x = new Vector2(gameObject.GetComponent<Collider>().bounds.min.x, gameObject.GetComponent<Collider>().bounds.max.x);
        for (int i = 0; i < objectCount; i++)
        {
            foreach (var spawn in spawnObjects)
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
