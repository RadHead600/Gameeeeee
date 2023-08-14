using System;

public class AddSpeed : Upgrade
{
    public override void Activate(Unit unit)
    {
        UnityEngine.Debug.Log(Parameters);
        unit.Speed += float.Parse(Parameters.ToString());
    }
}
