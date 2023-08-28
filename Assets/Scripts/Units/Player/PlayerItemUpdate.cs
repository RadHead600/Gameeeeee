using UnityEngine;

public class PlayerItemUpdate : MonoBehaviour
{
    private Hand _hand;
    private GameObject _weaponSave;

    private void Awake()
    {
        SetHand(gameObject);
    }

    public void SetItem(ShopItem item, int itemNum)
    {
        if (item.ItemObject.GetComponent<Skin>() != null)
        {
            SetSkin(item);
            SaveParameters.SkinEquip = itemNum;
            return;
        }

        if (item.ItemObject.GetComponent<Weapon>() != null)
        {
            if (_hand.HandWeapon != null) 
                Destroy(_hand.HandWeapon.gameObject);

            SetWeapon(item.ItemObject);
            SaveParameters.WeaponEquip = itemNum;
            return;
        }
    }

    private void SetWeapon(GameObject item)
    {
        if (item == null)
            return;
        _hand.SetHandWeapon();
        GameObject weapon = Instantiate(item);
        weapon.transform.parent = _hand.transform;
        weapon.transform.localScale = Vector3.one;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        _weaponSave = weapon;
        SetObjectLayer(weapon, gameObject.layer);
    }

    private void SetSkin(ShopItem item)
    {
        GameObject skin = Instantiate(item.ItemObject);
        skin.transform.SetParent(gameObject.transform);
        Transform skinT = gameObject.GetComponentInChildren<Skin>().transform;
        skin.transform.localScale = skinT.localScale;
        skin.transform.localPosition = skinT.localPosition;
        skin.transform.position = skinT.position;
        skin.transform.localRotation = skinT.localRotation;
        Destroy(skinT.gameObject);
        SetObjectLayer(skin, gameObject.layer);
        _hand = SetHand(skin);
        SetWeapon(_weaponSave);
    }

    private void SetObjectLayer(GameObject item, int layer)
    {
        foreach (var obj in item.GetComponentsInChildren<Transform>())
        {
            obj.gameObject.layer = layer;
        }
    }

    private Hand SetHand(GameObject body)
    {
        return body.GetComponentInChildren<Hand>();
    }
}
