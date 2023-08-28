using UnityEngine;

public class Gold : Item
{
    [Header("How much currency does the player get for one raised coin")]
    [SerializeField] private int _amountCurrency;

    public override void Active()
    {
        SaveParameters.Golds += _amountCurrency;
    }
}
