using UnityEngine;

public class TakeUpgradePoints : Singleton<TakeUpgradePoints>
{
    [SerializeField] private UpgradePointsParameters _upgradePointsParameters;
    
    public void TakeGems()
    {
        var timer = PointsTimer.Instance;
        foreach (float gemTime in _upgradePointsParameters.TimesToPoints)
        {
            if (gemTime <= timer.RemainingTimeInProcent)
            {
                GameInformation.Instance.UpgradePoints += _upgradePointsParameters.NumOfPoints;
            }
        }
    }

    private void OnDestroy()
    {
        LevelProgress.Instance.OnCompletedLevel -= TakeGems;
    }
}
