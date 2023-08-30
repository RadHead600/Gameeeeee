public class UpgradeAddSpeed : Upgrade
{
    private void Start()
    {
        UnitUpgrade.OnSpeedSet += LastValueUpdate;
        SetUpgradeLevel();
    }

    protected override void SetUpgradeLevel()
    {
        UpgradeId = 1;
        base.SetUpgradeLevel();
        foreach (var upgrade in SaveParameters.UpgradesLevel)
        {
            if (upgrade.Item1 == UpgradeId)
            {
                UnitUpgrade.SetStaticSpeed(UnitUpgrade.Speed + float.Parse(Parameters.ToString()) * upgrade.Item2);
            }
        }
    }

    public override void Activate()
    {
        base.Activate();
        if (SaveParameters.UpgradePoints - CostUpgrade >= 0)
        {
            SaveParameters.UpgradePoints -= CostUpgrade;
            UnitUpgrade.SetStaticSpeed(UnitUpgrade.Speed + float.Parse(Parameters.ToString()));
            LastValue = UnitUpgrade.Speed.ToString();
        }
    }

    public void LastValueUpdate(float amount)
    {
        LastValue = amount.ToString();
    }

    public void OnDestroy()
    {
        UnitUpgrade.OnSpeedSet -= LastValueUpdate;
    }
}
