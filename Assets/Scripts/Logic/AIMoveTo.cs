using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMoveTo : MonoBehaviour
{
    [SerializeField] private float _trackingUpdateTime = 1.5f;
    
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
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
