using System;

public class UpgradeAddHealthPoints : Upgrade
{
    private void Start()
    {
        UnitUpgrade.OnHealthChange += LastValueUpdate;
        LastValueUpdate(UnitUpgrade.Health);
    }

    public override void Activate()
    {
        base.Activate();
        if (SaveParameters.UpgradePoints - CostUpgrade >= 0)
        {
            SaveParameters.UpgradePoints -= CostUpgrade;
            UnitUpgrade.AddHealth(Convert.ToInt32(Parameters));
        }
    }

    public void LastValueUpdate(int amount)
    {
        LastValue = amount.ToString();
    }

    public void OnDestroy()
    {
        UnitUpgrade.OnHealthChange -= LastValueUpdate;
    }
}
