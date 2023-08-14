using System;

public class AddHealthPoints : Upgrade
{
    public override void Activate(Unit unit)
    {
        unit.HealthPoints += Convert.ToInt32(Parameters);
    }
}
