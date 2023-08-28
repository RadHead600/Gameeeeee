using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveTo : MonoBehaviour
{
    [SerializeField] private float _trackingUpdateTime = 1.5f;
    [SerializeField] private NavMeshAgent _agent;

    public NavMeshAgent NavMeshAgent => _agent;

    private void Start()
    {
        StartCoroutine(GoToObject());
    }

    private IEnumerator GoToObject()
    {
        yield return new WaitForSeconds(_trackingUpdateTime);
        if (PlayerMovement.Instance.MoveVector != Vector3.zero)
        {
            _agent.SetDestination(PlayerMovement.Instance.transform.position);
        }
        StartCoroutine(GoToObject());
    }
}
