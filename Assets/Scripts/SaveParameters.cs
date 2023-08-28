using System;

public static class SaveParameters
{
    private static int _golds;
    private static int _gems;
    private static int _passedLevel;
    private static int _upgradePoints;
    private static int _weaponEquip;
    private static int _skinEquip;

    public static int Golds 
    { 
        get { return _golds; }
        set 
        {
            _golds = value; 
            ChangeGolds?.Invoke(_golds); 
        } 
    }

    public static int Gems 
    {
        get { return _gems; }
        set
        {
            _gems = value;
            ChangeGems?.Invoke(_gems);
        }
    }

    public static int PassedLevel
    {
        get { return _passedLevel; }
        set
        {
            _passedLevel = value;
            ChangePassedLevel?.Invoke(_passedLevel);
        }
    }

    public static int UpgradePoints
    {
        get { return _upgradePoints; }
        set
        {
            _upgradePoints = value;
            ChangeUpgradePoints?.Invoke(_upgradePoints);
        }
    }

    public static int WeaponEquip
    {
        get { return _weaponEquip; }
        set
        {
            _weaponEquip = value;
            ChangeWeaponEquip?.Invoke(_weaponEquip);
        }
    }
    public static bool[] WeaponsBought { get; set; }

    public static int SkinEquip
    {
        get { return _skinEquip; }
        set
        {
            _skinEquip = value;
            ChangeSkinEquip?.Invoke(_skinEquip);
        }
    }
    public static bool[] SkinsBought { get; set; }

    public static event Action<int> ChangeGolds;
    public static event Action<int> ChangeGems;
    public static event Action<int> ChangePassedLevel;
    public static event Action<int> ChangeUpgradePoints;
    public static event Action<int> ChangeWeaponEquip;
    public static event Action<int> ChangeSkinEquip;
}
