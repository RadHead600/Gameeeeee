using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopParameters _items;
    [SerializeField] private ShopItemCard _itemCard;
    [SerializeField] private GameObject _itemsPanel;
    [SerializeField] private PlayerItemUpdate _character;

    private const string _isEquipedText = "Equipped";
    private const string _isEquipText = "Equip";
    private int _lastEquipedButton;

    private void Awake()
    {
        if (_items.Items.Count > 3)
        {
            SaveParameters.skinsBought = new bool[_items.Items.Count];
            SaveParameters.skinsBought[0] = true;
            SaveParameters.skinsBought[3] = true;
            Debug.Log("skinsBought");
            CreateItemCards();
            UnlockItems(SaveParameters.skinsBought);
            Equip(SaveParameters.skinEquip);
        }
        else
        {
            Debug.Log("weapon");
            SaveParameters.weaponsBought = new bool[_items.Items.Count];
            SaveParameters.weaponsBought[0] = true;
            SaveParameters.weaponsBought[2] = true;
            CreateItemCards();
            UnlockItems(SaveParameters.weaponsBought);
            Equip(SaveParameters.weaponEquip);
        }
        SaveParameters.money += 100000;
    }

    private void Start()
    {
    }

    private void CreateItemCards()
    {
        for (int i = 0; i < _items.Items.Count; i++)
        {
            int saveI = i;
            ShopItemCard card = Instantiate(_itemCard);
            card.transform.SetParent(_itemsPanel.transform);
            card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y, 0);
            card.transform.localScale = Vector3.one;
            card.transform.localPosition = Vector3.zero;
            card.ItemButton.onClick.AddListener(() => BuyItem(saveI));
            GameObject objectDemonstration = Instantiate(_items.Items[i].ItemObject);
            objectDemonstration.transform.SetParent(card.ItemDemonstrationObject.transform);
            objectDemonstration.transform.localRotation = _items.Items[i].ItemObject.transform.localRotation;
            objectDemonstration.transform.localPosition = Vector3.zero;
            objectDemonstration.transform.localScale = new Vector3(_items.Items[i].ItemObject.transform.localScale.x, _items.Items[i].ItemObject.transform.localScale.y, _items.Items[i].ItemObject.transform.localScale.z);
            card.CostText.text = _items.Items[i].ItemCost.ToString();
            card.NameText.text = _items.Items[i].ItemName.ToString();
        }
    }

    public void Equip(int itemNum)
    {
        _character.SetItem(_items.Items[itemNum], itemNum);
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[_lastEquipedButton].ItemButton.interactable = true;
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.interactable = false;
        ChangeItemPanelButtonText(_lastEquipedButton, _isEquipText);
        ChangeItemPanelButtonText(itemNum, _isEquipedText);
        _lastEquipedButton = itemNum;
    }

    public void UnlockItems(bool[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == false)
                continue;
            Unlockitem(i, _isEquipText);
        }
    }

    private void BuyItem(int itemNum)
    {
        if (SaveParameters.money < _items.Items[itemNum].ItemCost)
            return;

        SaveParameters.money -= _items.Items[itemNum].ItemCost;
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.onClick.RemoveAllListeners();
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.onClick.AddListener(() => Equip(itemNum));
        Unlockitem(itemNum, _isEquipText);
    }

    private void Unlockitem(int itemNum, string buttonText)
    {
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].CostText.alpha = 0;
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.onClick.RemoveAllListeners();
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.onClick.AddListener(() => Equip(itemNum));
        ChangeItemPanelButtonText(itemNum, buttonText);
    }

    private void ChangeItemPanelButtonText(int itemNum, string text)
    {
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}
