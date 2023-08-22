using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUpdater : Singleton<LevelProgressUpdater>
{
    [SerializeField] private Image _progressIndicator;
    [SerializeField] private TextMeshProUGUI _levelNumText;
    [SerializeField] private Canvas _upgradeCanvas;

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

    private void Start()
    {
        UpdateLevelNum(0);
    }

    private void UpdateProgressIndicator(float value)
    {
        _progressIndicator.fillAmount = value / RequiredNumberOfKills;
        if (_progressIndicator.fillAmount >= 1)
            UpdateLevelNum(++SaveParameters.passedLevel);
    }

    private void UpdateLevelNum(int num)
    {
        _levelNumText.text = num.ToString();
        CountKillsOnLevel = 0;
        if (num > 0)
            _upgradeCanvas.gameObject.SetActive(true);
        UpdateProgressIndicator(0);
    }
}
