public class ProtectiveWall : Unit
{
    public override void Die()
    {
        if (HealthPoints <= 0)
            Destroy(gameObject);
    }
}
