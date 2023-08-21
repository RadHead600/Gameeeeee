using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUpdater : MonoBehaviour
{
    [SerializeField] private Image _progressIndicator;
    [SerializeField] private TextMeshProUGUI _levelNumText;
    [SerializeField] private LevelParameters _levelParameters;

    private int _countEnemiesOnLevel;
    private int _countKillOnLevel;

    public int LevelSet { get; set; }

    public int CountKillOnLevel { 
        get { return _countKillOnLevel; }
        set
        {
            _countKillOnLevel = value;
            float progressValue = ((float)_countKillOnLevel / (float)_countEnemiesOnLevel);
            UpdateProgressIndicator(progressValue);
        } 
    }

    private void Start()
    {
        _countEnemiesOnLevel = _levelParameters.NumEnenmiesOnFirstLvl;
        UpdateProgressIndicator(0);
        UpdateLevelNum(0);
    }

    public void UpdateProgressIndicator(float value)
    {
        _progressIndicator.fillAmount = value;
        if (_progressIndicator.fillAmount >= 1)
            UpdateLevelNum(LevelSet++);
    }

    public void UpdateLevelNum(int num)
    {
        _levelNumText.text = num.ToString();
        if (num == 0)
            return;
        float per = ((float)_levelParameters.NumEnemiesPerLvlPercentage / 100);
        _countEnemiesOnLevel = _countEnemiesOnLevel + (int)((float)_countEnemiesOnLevel * per);
        _countKillOnLevel = 0;
        UpdateProgressIndicator(0);
    }
}
