using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemCard : MonoBehaviour
{
    [SerializeField] private Button _itemButton;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _moneyImage;
    [SerializeField] private GameObject _ItemDemonstrationObject;

    public Button ItemButton => _itemButton;
    public TextMeshProUGUI ButtonText => _buttonText;
    public TextMeshProUGUI CostText => _costText;
    public TextMeshProUGUI NameText => _nameText;
    public Image MoneyImage => _moneyImage;
    public GameObject ItemDemonstrationObject => _ItemDemonstrationObject;
}
