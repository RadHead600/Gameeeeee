using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUpdater : Singleton<LevelProgressUpdater>
{
    [SerializeField] private Image _progressIndicator;
    [SerializeField] private TextMeshProUGUI _levelNumText;

    private int _countKillsOnLevel;

    public int CountKillsOnLevel 
    {
        get { return _countKillsOnLevel; }
        set
        {
            _countKillsOnLevel = value;
            UpdateProgressIndicator(_countKillsOnLevel);
        }
    }

    public int RequiredNumberOfKills { get; set; }

    public event Action OnCompletedLevel;

    private void Start()
    {
        UpdateLevelNum(0);
        OnCompletedLevel += () => UpdateLevelNum(++SaveParameters.PassedLevel);
    }

    private void UpdateProgressIndicator(float value)
    {
        _progressIndicator.fillAmount = value / RequiredNumberOfKills;
        if (_progressIndicator.fillAmount >= 1)
            OnCompletedLevel?.Invoke();
    }

    private void UpdateLevelNum(int num)
    {
        _levelNumText.text = num.ToString();
        CountKillsOnLevel = 0;
        UpdateProgressIndicator(0);
    }
}
