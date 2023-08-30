using System;
using System.Diagnostics;

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
        if (SaveParameters.PassedLevel == 0)
            SaveParameters.PassedLevel = 1;
        LevelProgressUI.Instance.UpdateLevelNumText(SaveParameters.PassedLevel);
        OnCompletedLevel += UpdateLevelParameters;
    }

    private void UpdateLevelParameters()
    {
        CountKillsOnLevel = 0;
        LevelProgressUI.Instance.UpdateLevelNumText(++SaveParameters.PassedLevel);
    }

    private void OnDestroy()
    {
        OnCompletedLevel -= UpdateLevelParameters;
        OnCompletedLevel = null;
    }
}
