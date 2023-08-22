using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopParameters _shopParameters;
    [SerializeField] private ShopItemCard _itemCard;
    [SerializeField] private GameObject _itemsPanel;
    [SerializeField] private PlayerItemUpdate _character;

    private const string _isEquipedText = "Equipped";
    private const string _isEquipText = "Equip";
    private int _lastEquipedButton;

    public ShopParameters ShopParameters => _shopParameters;

    private void Awake()
    {
        CreateItemCards();
        gameObject.SetActive(false);
    }

    private void CreateItemCards()
    {
        for (int i = 0; i < _shopParameters.Items.Count; i++)
        {
            int saveI = i;
            ShopItemCard card = Instantiate(_itemCard);
            card.transform.SetParent(_itemsPanel.transform);
            card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y, 0);
            card.transform.localScale = Vector3.one;
            card.transform.localPosition = Vector3.zero;
            card.ItemButton.onClick.AddListener(() => BuyItem(saveI));
            GameObject objectDemonstration = Instantiate(_shopParameters.Items[i].ItemObject);
            objectDemonstration.transform.SetParent(card.ItemDemonstrationObject.transform);
            objectDemonstration.transform.localRotation = _shopParameters.Items[i].ItemObject.transform.localRotation;
            objectDemonstration.transform.localPosition = Vector3.zero;
            objectDemonstration.transform.localScale = new Vector3(_shopParameters.Items[i].ItemObject.transform.localScale.x, _shopParameters.Items[i].ItemObject.transform.localScale.y, _shopParameters.Items[i].ItemObject.transform.localScale.z);
            card.CostText.text = _shopParameters.Items[i].ItemCost.ToString();
            card.NameText.text = _shopParameters.Items[i].ItemName.ToString();
            Sprite moneySprite = _shopParameters.MoneySprites[((int)_shopParameters.Items[i].MoneyType)];
            if (moneySprite != null)
                card.MoneyImage.sprite = moneySprite;
        }
    }

    public void Equip(int itemNum)
    {
        _character.SetItem(_shopParameters.Items[itemNum], itemNum);
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
        int money = _shopParameters.Items[itemNum].MoneyType == ItemMoneyType.Gold ? SaveParameters.golds : SaveParameters.gems;
        if (money < _shopParameters.Items[itemNum].ItemCost)
            return;

        money -= _shopParameters.Items[itemNum].ItemCost;
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.onClick.RemoveAllListeners();
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.onClick.AddListener(() => Equip(itemNum));
        Unlockitem(itemNum, _isEquipText);
    }

    private void Unlockitem(int itemNum, string buttonText)
    {
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].CostText.alpha = 0;
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].MoneyImage.color = new Color(0, 0, 0, 0);
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.onClick.RemoveAllListeners();
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.onClick.AddListener(() => Equip(itemNum));
        ChangeItemPanelButtonText(itemNum, buttonText);
    }

    private void ChangeItemPanelButtonText(int itemNum, string text)
    {
        _itemsPanel.GetComponentsInChildren<ShopItemCard>()[itemNum].ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}
