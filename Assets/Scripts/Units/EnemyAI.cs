using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Enemy
{
    [SerializeField] private AIMoveTo aIMoveTo;

    public NavMeshAgent NavMeshAgent => aIMoveTo.NavMeshAgent;
}
