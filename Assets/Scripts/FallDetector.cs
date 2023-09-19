using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("CarBody"))
        {
            RCC.Transport(new Vector3(0,0.5f,0), Quaternion.identity);
            if(finishPanel.gameObject.activeSelf)
            {
                finishPanel.SetActive(false);
            }
        }
    }
}
