using UnityEngine;

public class PlayerItemUpdate : MonoBehaviour
{
    [SerializeField] private GameObject _hand;

    private void Awake()
    {
        SetHand();
    }

    public void SetItem(ShopItem item, int itemNum)
    {

        if (item.ItemObject.GetComponent<Skin>() != null)
        {
            SetSkin(item);
            SaveParameters.skinEquip = itemNum;
            return;
        }

        foreach (Transform weaponT in _hand.GetComponentInChildren<Transform>())
            Destroy(weaponT.gameObject);
        if (item.ItemObject.GetComponent<Weapon>() != null)
        {
            SetWeapon(item);
            SaveParameters.weaponEquip = itemNum;
            return;
        }
    }

    private void SetWeapon(ShopItem item)
    {
        GameObject weapon = Instantiate(item.ItemObject);
        weapon.transform.parent = _hand.transform;
        weapon.transform.localScale = Vector3.one;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
    }

    private void SetSkin(ShopItem item)
    {
        GameObject skin = Instantiate(item.ItemObject);
        skin.transform.SetParent(gameObject.transform);
        Transform skinT = gameObject.GetComponentInChildren<Skin>().transform;
        skin.transform.localScale = skinT.localScale;
        skin.transform.localPosition = skinT.localPosition;
        skin.transform.position = skinT.position;
        SetHand();
        Destroy(skinT.gameObject);
    }

    private void SetHand()
    {
        foreach (Transform bodyParts in gameObject.GetComponentInChildren<Transform>())
        {
            if (bodyParts.name == "hand")
            {
                _hand = bodyParts.gameObject;
            }
        }
    }
}
