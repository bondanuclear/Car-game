using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarConditionTracker : MonoBehaviour
{
    [Header("Low Gas Condition:")]
    [SerializeField] GameObject gasWarning;
    [SerializeField] GameObject lowGasPanel;
    LevelLoader levelLoader;
    RCC_CarControllerV3 playerCar;
    bool isNotified = false;
    private void Awake() 
    {
        levelLoader = GetComponent<LevelLoader>();    
    }
    
    void Start()
    {
        playerCar = levelLoader.Car;
    }

    
    void Update()
    {
        if(playerCar.fuelTank <= 10f && !isNotified)
        {
            gasWarning.SetActive(true);
            isNotified = true;
        } else if(playerCar.fuelTank < 0.1f) 
        {
            lowGasPanel.SetActive(true);
            Debug.Log("setting active");
        }
    }
}
