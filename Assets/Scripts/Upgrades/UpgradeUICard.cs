using System;
using TMPro;
using UnityEngine;

public class UpgradeUICard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private UpgradeTypeParameters _type;

    private void OnEnable()
    {
        foreach (var card in gameObject.GetComponentsInChildren<Upgrade>())
        {
            card.SetRandomParameters();
            if (_type == UpgradeTypeParameters.Int)
            {
                _infoText.text = card.LastValue + " >> " + ((int)Convert.ToDouble(card.LastValue) + (int)Convert.ToDouble(card.Parameters.ToString()));
                return;
            }
            _infoText.text = card.LastValue + " >> " + (Convert.ToDouble(card.LastValue) + Convert.ToDouble(card.Parameters.ToString()));
        }
    }
}

public enum UpgradeTypeParameters
{
    Int,
    Float
}