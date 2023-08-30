using System;
using System.Diagnostics;

public class UpgradeAddHealthPoints : Upgrade
{
    private void Start()
    {
        UnitUpgrade.OnHealthSet += LastValueUpdate;
        SetUpgradeLevel();
    }

    protected override void SetUpgradeLevel()
    {
        UpgradeId = 0;
        base.SetUpgradeLevel();
        foreach (var upgrade in SaveParameters.UpgradesLevel)
        {
            if (upgrade.Item1 == UpgradeId)
            {
                UnitUpgrade.SetStaticHealth(UnitUpgrade.Health + Convert.ToInt32(Parameters) * upgrade.Item2);
            }
        }
    }

    public override void Activate()
    {
        base.Activate();
        if (SaveParameters.UpgradePoints - CostUpgrade >= 0)
        {
            SaveParameters.UpgradePoints -= CostUpgrade;
            UnitUpgrade.SetStaticHealth(UnitUpgrade.Health + Convert.ToInt32(Parameters));
        }
    }

    public void LastValueUpdate(int amount)
    {
        LastValue = amount.ToString();
    }

    public void OnDestroy()
    {
        UnitUpgrade.OnHealthSet -= LastValueUpdate;
    }
}
