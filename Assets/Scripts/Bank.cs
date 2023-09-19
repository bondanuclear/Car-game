using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank bankInstance;

    int dollarAmount = 1000;
    int gemAmount = 50;

    public int DollarAmount {get; private set;}
    public int GemAmount { get; private set; }
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
