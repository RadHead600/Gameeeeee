using UnityEngine;

public class PlayerItemUpdate : MonoBehaviour
{
    private GameObject _hand;
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
            SaveParameters.skinEquip = itemNum;
            return;
        }

        if (item.ItemObject.GetComponent<Weapon>() != null)
        {
            if (_hand == null)
                return;
            foreach (Weapon weaponT in _hand.GetComponentsInChildren<Weapon>())
                Destroy(weaponT.gameObject);

            SetWeapon(item.ItemObject);
            SaveParameters.weaponEquip = itemNum;
            return;
        }
    }

    private void SetWeapon(GameObject item)
    {
        if (item == null)
            return;
        if (_hand == null)
        {
            SetHand(gameObject);
            if (_hand == null)
                return;
        }
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
        SetHand(skin);
        SetWeapon(_weaponSave);
    }

    private void SetObjectLayer(GameObject item, int layer)
    {
        foreach (var obj in item.GetComponentsInChildren<Transform>())
        {
            obj.gameObject.layer = layer;
        }
    }

    private void SetHand(GameObject gm)
    {
        foreach (Transform bodyParts in gm.GetComponentsInChildren<Transform>())
        {
            if (bodyParts.name.ToLower() == "hand")
            {
                _hand = bodyParts.gameObject;
                return;
            }
        }
        Debug.Log("The hand was not added to the character's skin!");
    }
}
