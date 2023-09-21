using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    [Header("Daily reward parameters")]
    
    [SerializeField] int dollarAmountDaily;
    public int DollarAmountDaily {get {return dollarAmountDaily;}}
    [SerializeField] int gemsAmountDaily;
    public int GemsAmountDaily { get { return gemsAmountDaily; } }
    [Header("Ad Reward")]
    [SerializeField] int adDollars;
    public int AdDollars {get {return adDollars;}}
    [SerializeField] int adGems;
    public int AdGems {get {return adGems;}}
    

    private void Awake() {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            
            Destroy(gameObject);
        }
       
    }
    public void CollectReward()
    {
       Bank.bankInstance.AddDollars(dollarAmountDaily);
        Bank.bankInstance.AddGems(gemsAmountDaily);
      

    }
    public void DoubleRewardDaily()
    {
        Debug.Log("Watching ad...");
        Bank.bankInstance.AddDollars(dollarAmountDaily);
        Bank.bankInstance.AddGems(gemsAmountDaily);
       
    }
    public void GetDollars(int dollarsAmount)
    {
        Bank.bankInstance.AddDollars(dollarsAmount);
    }
    public void GetGems(int gemAmount)
    {
        Bank.bankInstance.AddGems(gemAmount);
    }
    public void AdDollarsReward()
    {
        Bank.bankInstance.AddDollars(adDollars);
    }
    public void AdGemsReward()
    {
        Bank.bankInstance.AddGems(adGems);
    }
   
}
