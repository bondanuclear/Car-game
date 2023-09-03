using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitch : MonoBehaviour
{
    //[SerializeField] int amount = 2;
    [SerializeField] GameObject[] cars;
    int currentIndex = 0;
    int previousIndex;
    public void SwitchCar(int direction)
    {
        previousIndex = currentIndex;
        int currValue = currentIndex + direction;
        currentIndex = currValue >= 0 ? currValue % cars.Length : (cars.Length-1);
        //Debug.Log($"Current index {currentIndex}, previous: {previousIndex}");
        cars[previousIndex].SetActive(false);
        cars[currentIndex].SetActive(true);
    }
    public void TestButton()
    {
        Debug.Log("It's working !");
    }
}
