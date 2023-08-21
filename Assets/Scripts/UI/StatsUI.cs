using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _gemText;

    private void Start()
    {
        UpdateGemText();
        UpdateGoldText();
    }

    public void UpdateGoldText()
    {
        _goldText.text = SaveParameters.golds.ToString();
    }

    public void UpdateGemText()
    {
        _gemText.text = SaveParameters.gems.ToString();
    }
}
