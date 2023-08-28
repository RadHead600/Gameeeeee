using System;

public class UpgradeAddSpeed : Upgrade
{
    private void OnEnable()
    {
        LastValue = UnitUpgrade.Speed.ToString();
    }

    public override void Activate()
    {
        base.Activate();
        if (SaveParameters.UpgradePoints - CostUpgrade >= 0)
        {
            SaveParameters.UpgradePoints -= CostUpgrade;
            UnitUpgrade.Speed += float.Parse(Parameters.ToString());
            LastValue = UnitUpgrade.Speed.ToString();
        }
    }
}
