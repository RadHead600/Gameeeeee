using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class Information
{
    public int golds;
    public int gems;
    public int passedLevel;
    public int upgradePoints;
    public int weaponEquip;
    public int skinEquip;
    public List<int> weaponsBought;
    public List<int> skinsBought;
    // Id Upgrade, level upgrade 
    public List<(int, int)> upgradesLevel;
}

public class GameInformation : Singleton<GameInformation>
{
    private Information _information;
    public int Golds 
    { 
        get { return _information.golds; }
        set 
        {
            _information.golds = value; 
            ChangeGolds?.Invoke(_information.golds);
            Save();
        } 
    }

    public int Gems 
    {
        get { return _information.gems; }
        set
        {
            _information.gems = value;
            ChangeGems?.Invoke(_information.gems);
            Save();
        }
    }

    public int PassedLevel
    {
        get { return _information.passedLevel; }
        set
        {
            _information.passedLevel = value;
            ChangePassedLevel?.Invoke(_information.passedLevel);
            Save();
        }
    }

    public int UpgradePoints
    {
        get { return _information.upgradePoints; }
        set
        {
            _information.upgradePoints = value;
            ChangeUpgradePoints?.Invoke(_information.upgradePoints);
            Save();
        }
    }

    public int WeaponEquip
    {
        get { return _information.weaponEquip; }
        set
        {
            _information.weaponEquip = value;
            ChangeWeaponEquip?.Invoke(_information.weaponEquip);
            Save();
        }
    }

    public int SkinEquip
    {
        get { return _information.skinEquip; }
        set
        {
            _information.skinEquip = value;
            Save();
            ChangeSkinEquip?.Invoke(_information.skinEquip);
        }
    }

    public List<int> WeaponsBought
    {
        get { return _information.weaponsBought; }
        set
        {
            _information.weaponsBought = value;
            Save();
        }
    }

    public List<int> SkinsBought
    {
        get { return _information.skinsBought; }
        set
        {
            _information.skinsBought = value;
            Save();
        }
    }

    // Id Upgrade, level upgrade 
    public List<(int, int)> UpgradesLevel
    {
        get { return _information.upgradesLevel; }
        set
        {
            _information.upgradesLevel = value;
            Save();
        }
    }

    public event Action<int> ChangeGolds;
    public event Action<int> ChangeGems;
    public event Action<int> ChangePassedLevel;
    public event Action<int> ChangeUpgradePoints;
    public event Action<int> ChangeWeaponEquip;
    public event Action<int> ChangeSkinEquip;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    protected override void Awake()
    {
        base.Awake();
#if UNITY_WEBGL && !UNITY_EDITOR
        LoadExtern();
#endif
    }

    private void Start()
    {
        if (_information == null)
            _information = new Information();
    }

    public void SetInformationFromJSON(string info)
    {
        _information = JsonUtility.FromJson<Information>(info);
    }

    public void Save()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        string json = JsonUtility.ToJson(_information);
        SaveExtern(json);
#endif
    }
}
