using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    PersistentData persistentData;
    RCC_CarControllerV3 car;
    RCC_Camera rcc_Camera;
    private void Awake() {
        persistentData = FindObjectOfType<PersistentData>();
    }
    private void Start() {
        //Debug.Log("Check value :" + persistentData.CarIndex);
        car = RCC.SpawnRCC(persistentData.GetCar, Vector3.zero, Quaternion.identity, true, true, true);
    }
}
