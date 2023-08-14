using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMoveTo : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (_playerMovement.MoveVector != Vector3.zero)
        {
            agent.SetDestination(_playerMovement.transform.position);
        }
    }
}
