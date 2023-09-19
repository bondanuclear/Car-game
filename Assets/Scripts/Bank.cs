using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank bankInstance;

    int dollarAmount = 1000;
    int gemAmount = 50;

    public int DollarAmount {get; set;}
    public int GemAmount { get; set; }
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

}
