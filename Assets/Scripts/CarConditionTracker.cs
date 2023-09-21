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
    Rigidbody _rigidbody;
    private void Awake() 
    {
        levelLoader = GetComponent<LevelLoader>();
        
    }
    
    void Start()
    {
        playerCar = levelLoader.Car;
        Debug.Log(playerCar.damage);
        _rigidbody = playerCar.GetComponent<Rigidbody>();
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
            
        }
        
    }

    public void FillTheTank()
    {
        playerCar.fuelTank = playerCar.fuelTankCapacity;
        isNotified = false;
        lowGasPanel.SetActive(false);
        gasWarning.SetActive(false);
        playerCar.StartEngine();
    }
}
