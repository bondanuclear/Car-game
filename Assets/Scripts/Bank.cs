using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank bankInstance;

    int dollarAmount = 1000;
    int gemAmount = 50;

    public int DollarAmount {get {return dollarAmount;}}
    public int GemAmount { get { return gemAmount; } }
    private void Awake() {
        if(bankInstance == null)
        {
            bankInstance = this;
        } else if(bankInstance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void AddDollars(int amount)
    {
        dollarAmount += amount;
    }
    public void AddGems(int amount)
    {
        gemAmount += amount;
    }
}
