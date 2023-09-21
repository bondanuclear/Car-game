using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarConditionTracker : MonoBehaviour
{
    [SerializeField] private float BRAKE_FORCE = 50000f;
    [Header("Low Gas Condition:")]
    [SerializeField] GameObject gasWarning;
    [SerializeField] GameObject lowGasPanel;
    LevelLoader levelLoader;
    RCC_CarControllerV3 playerCar;
    bool isNotified = false;
    Rigidbody _rigidbody;
    FinishLineManager finishLineManager;
    FallDetector fallDetector;
    private void Awake() 
    {
        levelLoader = GetComponent<LevelLoader>();
        finishLineManager = FindObjectOfType<FinishLineManager>();
        fallDetector = FindObjectOfType<FallDetector>();
    }
    
    void Start()
    {
        playerCar = levelLoader.Car;
        Debug.Log(playerCar.damage);
        _rigidbody = playerCar.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(finishLineManager.hasFinished || fallDetector.hasFailed)
        {
            gasWarning.SetActive(false);
            lowGasPanel.SetActive(false);
        }
        else
        {
            if(playerCar.fuelTank <= 10f && !isNotified)
            {
                gasWarning.SetActive(true);
                isNotified = true;
            } else if(playerCar.fuelTank < 0.1f) 
            {
                lowGasPanel.SetActive(true);
                playerCar.handbrakeInput = BRAKE_FORCE;
            }
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
