using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData instance;
    [SerializeField] GameObject[] carArray;
    
    [SerializeField] int carIndex;
    public int CarIndex {get {return carIndex;} set{ carIndex = value;} }
    public RCC_CarControllerV3 GetCar {get {return carArray[carIndex].GetComponent<RCC_CarControllerV3>();} }
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

}
