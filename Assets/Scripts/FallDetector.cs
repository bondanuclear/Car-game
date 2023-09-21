using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    const string CAR_COLLIDER = "CarBody";
    [SerializeField] float brakeForce = 500f;
    LevelLoader levelLoader;
    [SerializeField] GameObject levelFailedPanel;
    [SerializeField] GameObject controls;
    public bool hasFailed = false;

    private void Start() {
        levelLoader = FindObjectOfType<LevelLoader>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(CAR_COLLIDER))
        {
            RCC.Transport(new Vector3(0,0.5f,0), Quaternion.identity);
            hasFailed = true;
            levelFailedPanel.SetActive(true);
            levelLoader.Car.KillEngine();
            controls.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        levelFailedPanel.SetActive(false);
        levelLoader.Car.StartEngine();
        hasFailed = false;
        controls.SetActive(true);
    }
    private void Update() {
        if(hasFailed)
        {
            // somehow need to stop the vehicle -_-
        }
    }
}
