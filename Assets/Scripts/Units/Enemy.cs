public class Enemy : Unit
{
    public override void Die()
    {
        LevelProgressUpdater.Instance.CountKillsOnLevel += 1;
        base.Die();
    }
}
