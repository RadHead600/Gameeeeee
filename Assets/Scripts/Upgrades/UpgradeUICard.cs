using TMPro;
using UnityEngine;

public class UpgradeUICard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private UpgradeTypeParameters _type;
    [SerializeField] private Upgrade _cardInformation;

    private void Start()
    {
        _cardInformation.OnActivate += UpdateInformation;
        UpdateInformation();
    }

    public void UpdateInformation()
    {
        if (_type == UpgradeTypeParameters.Int)
        {
            _infoText.text = _cardInformation.LastValue + " >> " + (int)Sum();
            return;
        }
        
        _infoText.text = System.Math.Round(System.Convert.ToDouble(_cardInformation.LastValue), 2) + " >> " + System.Math.Round(Sum(), 2);
    }

    private double Sum()
    {
        return System.Convert.ToDouble(_cardInformation.LastValue) + System.Convert.ToDouble(_cardInformation.Parameters.ToString());
    }

    private void OnDestroy()
    {
        _cardInformation.OnActivate -= UpdateInformation;
    }
}

public enum UpgradeTypeParameters
{
    Int,
    Float
}
