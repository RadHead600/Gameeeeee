using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Enemy
{
    [SerializeField] private AIMoveTo _aIMoveTo;

    public NavMeshAgent NavMeshAgent => _aIMoveTo.NavMeshAgent;
    private bool isJump;

    protected override void Awake()
    {
        base.Awake();
        OnDeath += _aIMoveTo.StopMove;
    }

    private void Start()
    {
        Skin.Animator.SetFloat("Speed", NavMeshAgent.speed);
    }

    private void FixedUpdate()
    {
        if (_aIMoveTo.IsJump() != isJump)
        {
            Skin.Animator.SetBool("Jump", _aIMoveTo.IsJump());
            isJump = _aIMoveTo.IsJump();
            return;
        }
        if (Attack.IsAttack)
        {
            Skin.Animator.SetFloat("Speed", 0);
            return;
        }
        Skin.Animator.SetFloat("Speed", NavMeshAgent.speed);
    }


    protected override void OnDestroy()
    {
        OnDeath -= _aIMoveTo.StopMove;
        base.OnDestroy();
    }
}
