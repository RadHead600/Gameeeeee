using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _gemText;
    [SerializeField] private TextMeshProUGUI _upgradePointsText;

    private void Awake()
    {
        SaveParameters.ChangeGolds += UpdateGoldText;
        SaveParameters.ChangeGems += UpdateGemText;
        SaveParameters.ChangeUpgradePoints += UpdatePointsText;
        SaveParameters.UpgradePoints = 8;
    }

    public void UpdateGoldText(int amount)
    {
        _goldText.text = amount.ToString();
    }

    public void UpdateGemText(int amount)
    {
        _gemText.text = amount.ToString();
    }

    public void UpdatePointsText(int amount)
    {
        _upgradePointsText.text = amount.ToString();
    }

    private void OnDestroy()
    {
        SaveParameters.ChangeGolds -= UpdateGoldText;
        SaveParameters.ChangeGems -= UpdateGemText;
        SaveParameters.ChangeUpgradePoints -= UpdatePointsText;
    }
}
