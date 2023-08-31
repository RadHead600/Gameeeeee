using System;

public class LevelProgress : Singleton<LevelProgress>
{

    private int _countKillsOnLevel;

    public int CountKillsOnLevel 
    {
        get { return _countKillsOnLevel; }
        set
        {
            _countKillsOnLevel = value;
            float progress = (float)_countKillsOnLevel / RequiredNumberOfKills;
            LevelProgressUI.Instance.UpdateProgressIndicator(progress);
            if (progress >= 1)
                OnCompletedLevel?.Invoke();
        }
    }

    public int RequiredNumberOfKills { get; set; }

    public Action OnCompletedLevel;

    private void Start()
    {
        if (GameInformation.Instance.PassedLevel == 0)
            GameInformation.Instance.PassedLevel = 1;
        LevelProgressUI.Instance.UpdateLevelNumText(GameInformation.Instance.PassedLevel);
        OnCompletedLevel += UpdateLevelParameters;
    }

    private void UpdateLevelParameters()
    {
        CountKillsOnLevel = 0;
        LevelProgressUI.Instance.UpdateLevelNumText(++GameInformation.Instance.PassedLevel);
    }

    private void OnDestroy()
    {
        OnCompletedLevel -= UpdateLevelParameters;
        OnCompletedLevel = null;
    }
}
