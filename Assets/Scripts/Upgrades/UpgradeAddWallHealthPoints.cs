using System;

public class UpgradeAddWallHealthPoints : Upgrade
{
    private void Start()
    {
        UnitUpgrade.OnHealthSet += LastValueUpdate;
        SetUpgradeLevel();
    }

    protected override void SetUpgradeLevel()
    {
        UpgradeId = 2;
        base.SetUpgradeLevel();
        foreach (var upgrade in GameInformation.Instance.UpgradesLevel)
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
        if (GameInformation.Instance.UpgradePoints - CostUpgrade >= 0)
        {
            GameInformation.Instance.UpgradePoints -= CostUpgrade;
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
