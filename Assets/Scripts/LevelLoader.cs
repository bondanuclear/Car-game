using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    [SerializeField] Vector3 spawnPoint = new Vector3(0,0.5f,0);
    
    PersistentData persistentData;
    RCC_CarControllerV3 car;
    RCC_Camera rcc_Camera;
    private void Awake() {
        persistentData = FindObjectOfType<PersistentData>();
        rcc_Camera = FindObjectOfType<RCC_Camera>();
    }
    private void Start() {
        //Debug.Log("Check value :" + persistentData.CarIndex);
        car = RCC.SpawnRCC(persistentData.GetCar, spawnPoint, Quaternion.identity, true, true, true);
        rcc_Camera.playerCar = car;
        
    }

    public void LoadGarageLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
