using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopParameters", menuName = "CustomParameters/Shop/ShopParameters")]
public class ShopParameters : ScriptableObject
{
    [SerializeField] private List<ShopItem> _items;

    public List<ShopItem> Items => _items;
}
