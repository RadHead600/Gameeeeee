public class UpgradeAddSpeed : Upgrade
{
    private void OnEnable()
    {
        LastValue = UnitUpgrade.Speed.ToString();
    }

    public override void Activate()
    {
        UnitUpgrade.Speed += float.Parse(Parameters.ToString());
        LastValue = UnitUpgrade.Speed.ToString();
    }
}
