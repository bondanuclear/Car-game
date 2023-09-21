using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Bank bank;
    AdManager adManager;
    [Header("Ad buttons")]
    [SerializeField] Button dailyButton;
    [SerializeField] Button daily2XButton;

    [Header("Amount of money")]

    [SerializeField] TextMeshProUGUI dollarsText;
    [SerializeField] TextMeshProUGUI gemsText;

    [Header("Panels")]
    [SerializeField] GameObject moneyPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject adPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject garagePanel;
    [SerializeField] GameObject levelsPanel;
    [SerializeField] GameObject dailyRewardPanel;


    [Header("Buttons")]
    [SerializeField] GameObject backButton;
    public static event Action<bool> OnPanelChanged;
    private void Awake() 
    {
        bank = FindObjectOfType<Bank>();
        adManager = FindObjectOfType<AdManager>();
    }
    
    private void Update()
    {
        dollarsText.text = bank.DollarAmount.ToString();
        gemsText.text = bank.GemAmount.ToString();
    }
    public void ActivateShopPanel()
    {
        ProcessMainMenu(false);
        shopPanel.SetActive(true);
    }
    public void ActivateMainMenuPanel()
    {
        if(garagePanel.activeSelf) ProcessGaragePanel(false);
        else 
        {
            moneyPanel.SetActive(true);
            shopPanel.SetActive(false);
            levelsPanel.SetActive(false);
            dailyRewardPanel.SetActive(false);
            ProcessMainMenu(true);
        }
        
    }
    public void ProcessGaragePanel(bool toActivate)
    {
        ProcessMainMenu(!toActivate);
        garagePanel.SetActive(toActivate);
        OnPanelChanged?.Invoke(toActivate);
    }
    
    private void ProcessMainMenu(bool toActivate)
    {
        
        mainMenuPanel.SetActive(toActivate);
        adPanel.SetActive(toActivate);
        backButton.SetActive(!toActivate);
    }
    public void ActivateLevelsPanel()
    {
        moneyPanel.SetActive(false);
        levelsPanel.SetActive(true);
        ProcessMainMenu(false);
    }
    public void LoadTrack(int indexOfTrack)
    {
        StartCoroutine(LoadNextLevel(indexOfTrack));
    }
    public void ActivateDailyReward()
    {
        ProcessMainMenu(false);
        dailyRewardPanel.SetActive(true);
    }
    private IEnumerator LoadNextLevel(int levelIndex)
    {
        // add level transition if needed
        yield return null;
        SceneManager.LoadSceneAsync(levelIndex);

    }
    /////////// ad manager methods
    ///
    public void CollectReward()
    {
        AdManager.instance.CollectReward();
        dailyButton.gameObject.SetActive(false);
    }
    public void DoubleRewardDaily()
    {
        AdManager.instance.DoubleRewardDaily();
        daily2XButton.gameObject.SetActive(false);
    }
    public void GetDollars(int dollarsAmount)
    {
        AdManager.instance.GetDollars(dollarsAmount);
    }
    public void GetGems(int gemAmount)
    {
        AdManager.instance.GetGems(gemAmount);
    }
    public void AdDollarsReward()
    {
        AdManager.instance.AdDollarsReward();
    }
    public void AdGemsReward()
    {
        AdManager.instance.AdGemsReward();
    }
}
