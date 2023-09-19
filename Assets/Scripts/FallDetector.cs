using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    const string CAR_COLLIDER = "CarBody";
    [SerializeField] GameObject finishPanel;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(CAR_COLLIDER))
        {
            RCC.Transport(new Vector3(0,0.5f,0), Quaternion.identity);
            if(finishPanel.gameObject.activeSelf)
            {
                finishPanel.SetActive(false);
            }
        }
    }
}
