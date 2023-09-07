using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Enemy
{
    [SerializeField] private AIMoveTo _aIMoveTo;

    public NavMeshAgent NavMeshAgent => _aIMoveTo.NavMeshAgent;
    private bool isJump;
    private bool isAttack;

    protected override void Awake()
    {
        base.Awake();
        OnDeath += _aIMoveTo.StopScript;
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
            _aIMoveTo.StopMove();
            Skin.Animator.SetFloat("Speed", 0);
            isAttack = true;
            return;
        }
        
        Skin.Animator.SetFloat("Speed", NavMeshAgent.speed);
        
        if (isAttack)
        {
            _aIMoveTo.Move();
            isAttack = false;
        }
    }

    protected override void OnDestroy()
    {
        OnDeath -= _aIMoveTo.StopScript;
        base.OnDestroy();
    }
}
