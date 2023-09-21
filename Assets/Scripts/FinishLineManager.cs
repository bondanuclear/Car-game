using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLineManager : MonoBehaviour
{
    [SerializeField] int levelReward = 2000;
    [SerializeField] TextMeshProUGUI rewardText;
    [SerializeField] GameObject[] finishLines;
    [SerializeField] TextMeshProUGUI inspectedCounter;
    [SerializeField] GameObject finishPanel;
    [SerializeField] int finishCounter = 2;
    int counter = 0;
    int currentIndex;
    Bank bank;
    public bool hasFinished;
    private void Awake() {
        bank = FindObjectOfType<Bank>();
    }
    private void OnEnable() 
    {
        FinishChecker.OnFinishPassed += AddPoints;
    }
    private void OnDisable()
    {
        FinishChecker.OnFinishPassed -= AddPoints;
    }
    private void Start() {
        inspectedCounter.text = "Gates Inspected: " + counter;
        GameObject randomGate = GetRandomGate();
        randomGate.SetActive(true);
    }
    private void AddPoints()
    {
        counter++;
        inspectedCounter.text = "Gates Inspected: " + counter;
        finishLines[currentIndex].SetActive(false);
        if (counter >= finishCounter)
        {
            rewardText.text = "Reward: " + levelReward;
            bank.AddDollars(levelReward);
            finishPanel.SetActive(true);
            hasFinished = true;
            return;
        }
        
       //finishLines[currentIndex].SetActive(false);
       GameObject randomGate = GetRandomGate();
       randomGate.SetActive(true);
       Debug.Log(counter);
    }

    private GameObject GetRandomGate()
    {
        int randomFinishIndex;
        do
        {
            randomFinishIndex = UnityEngine.Random.Range(0, finishLines.Length);
        }
        while (currentIndex == randomFinishIndex);
        
       
        
        currentIndex = randomFinishIndex;
        return finishLines[randomFinishIndex];
    }
    
}
