using System;

public class UpgradeAddWallHealthPoints : Upgrade
{
    private void OnEnable()
    {
        LastValue = UnitUpgrade.HealthPoints.ToString();
    }

    public override void Activate()
    {
        UnitUpgrade.HealthPoints += Convert.ToInt32(Parameters);
        LastValue = UnitUpgrade.HealthPoints.ToString();
    }
}
