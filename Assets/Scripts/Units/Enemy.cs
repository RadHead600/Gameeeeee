using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private LevelProgressUpdater _levelUpdater;

    public override void Die()
    {
        _levelUpdater.CountKillOnLevel += 1;
        base.Die();
    }
}
