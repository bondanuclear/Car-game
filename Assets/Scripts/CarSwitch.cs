using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarSwitch : MonoBehaviour
{
    //[SerializeField] int amount = 2;
    [SerializeField] GameObject[] cars;
    int currentIndex = 0;
    int previousIndex;
    PersistentData persistentData;
    private void Start() {
        persistentData = FindObjectOfType<PersistentData>();
    }
    public void SwitchCar(int direction)
    {
        previousIndex = currentIndex;
        int currValue = currentIndex + direction;
        currentIndex = currValue >= 0 ? currValue % cars.Length : (cars.Length-1);
        //Debug.Log($"Current index {currentIndex}, previous: {previousIndex}");
        cars[previousIndex].SetActive(false);
        cars[currentIndex].SetActive(true);
    }
    
    public void PickCar(int levelIndex)
    {
        Debug.Log("You picked " + cars[currentIndex].gameObject.name);
        StartCoroutine(LoadNextLevel(levelIndex));
    }
    private IEnumerator LoadNextLevel(int levelIndex)
    {
        persistentData.CarIndex = currentIndex;
        yield return null;
        SceneManager.LoadSceneAsync(levelIndex);
        
    }
}
