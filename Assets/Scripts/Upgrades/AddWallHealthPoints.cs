public class AddWallHealthPoints : Upgrade
{
    public override void Activate(Unit unit)
    {
        UnityEngine.Debug.Log(Parameters);
        unit.HealthPoints += (int)Parameters;
    }
}
