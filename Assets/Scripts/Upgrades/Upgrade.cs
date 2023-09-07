using System;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradesParameters _upgradesParameters;
    [SerializeField] private Unit _unitUpgrade;

    public object Parameters { get; protected set; }
    public Unit UnitUpgrade => _unitUpgrade;
    public string LastValue { get; set; }
    public int CostUpgrade { get; set; }
    
    public int UpgradeId { get; set; }
    public int Level { get; set; }

    public Action OnActivate;

    protected virtual void Awake()
    {
        CostUpgrade = _upgradesParameters.MinCost;
        Parameters = _upgradesParameters.Value;

        int changeCount = 1;

         int levelImprovement = 0;
        
        if (GameInformation.Instance.Information.UpgradesLevel.Count - changeCount < UpgradeId)
        {
            for (int i = GameInformation.Instance.Information.UpgradesLevel.Count - changeCount; i < UpgradeId; i++)
            {
                GameInformation.Instance.Information.UpgradesLevel.Add(levelImprovement);
            }
            GameInformation.OnInformationChange?.Invoke();
        }
        
        ResetUpgradesPointsController.OnReset += ResetLevel;
        ResetUpgradesPointsController.OnReset += SetUpgradeLevel;
    }

    protected bool UpLevel()
    {
        int zero = 0;

        int preferredLevelImprovement = 1;
    
        bool isLiquid = GameInformation.Instance.Information.UpgradePoints - CostUpgrade >= zero;
        
        if (isLiquid)
        {
            GameInformation.Instance.Information.UpgradesLevel[UpgradeId] += preferredLevelImprovement;
            GameInformation.Instance.Information.UpgradePoints -= CostUpgrade;
            GameInformation.OnInformationChange?.Invoke();
        }
        return isLiquid;
    }

    public virtual void Activate()
    {
        GameInformation.OnInformationChange?.Invoke();
    }

    protected virtual void SetUpgradeLevel()
    {
    }

    protected void ResetLevel()
    {
        Level = 1;
    }

    protected virtual void OnDestroy()
    {
        ResetUpgradesPointsController.OnReset -= ResetLevel;
        ResetUpgradesPointsController.OnReset -= SetUpgradeLevel;
    }
}
