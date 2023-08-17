using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemCard : MonoBehaviour
{
    [SerializeField] private Button _itemButton;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private GameObject _ItemDemonstrationObject;

    public Button ItemButton => _itemButton;
    public TextMeshProUGUI CostText => _costText;
    public TextMeshProUGUI NameText => _nameText;
    public GameObject ItemDemonstrationObject => _ItemDemonstrationObject;
}
