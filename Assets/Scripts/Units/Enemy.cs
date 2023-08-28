using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [Header("Maximum the drop-down number of coins at death")]
    [SerializeField] private int _maxNumOfCoins;
    [Header("Minimum the drop-down number of coins at death")]
    [SerializeField] private int _minNumOfCoins;
    [SerializeField] private List<DropItemParameters> _itemsParameters;
    [SerializeField] private DropItem _dropItem;
    [SerializeField] private EnemiesParameters _enemiesParameters;

    protected override void Awake()
    {
        base.Awake();
        Health = _enemiesParameters.MinHealth;
    }

    public override void Die()
    {
        if (Health > 0)
            return;
        LevelProgressUpdater.Instance.CountKillsOnLevel += 1;
        foreach (var item in _itemsParameters)
        {
            _dropItem.DropItems(item.ItemPrefab, _minNumOfCoins, _maxNumOfCoins);
        }
        Destroy(gameObject);
    }
}
