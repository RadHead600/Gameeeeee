using System;
using UnityEngine;

[Serializable]
public class ShopItem
{
    [SerializeField] private string _itemName;
    [SerializeField] private int _itemCost;
    [SerializeField] private GameObject _itemObject;

    public string ItemName => _itemName;
    public int ItemCost => _itemCost;
    public GameObject ItemObject => _itemObject;
}