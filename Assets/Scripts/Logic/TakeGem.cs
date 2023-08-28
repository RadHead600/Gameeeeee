using UnityEngine;

public class TakeGem : Singleton<TakeGem>
{
    [SerializeField] private UpgradePointsParameters _upgradePointsParameters;
    
    public void TakeGems()
    {
        var timer = UpgradePointsTimer.Instance;
        foreach (float gemTime in _upgradePointsParameters.TimesToGem)
        {
            if (gemTime <= timer.RemainingTimeInProcent)
            {
                SaveParameters.UpgradePoints += _upgradePointsParameters.NumOfGems;
            }
        }
    }

    private void OnDestroy()
    {
        LevelProgressUpdater.Instance.OnCompletedLevel -= TakeGems;
    }
}
