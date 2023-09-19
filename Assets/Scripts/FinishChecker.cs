using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;
    const string CAR_COLLIDER = "CarBody";
    private void OnTriggerEnter(Collider other) {
        //Debug.Log($"Triggered by {other.gameObject.tag}");
        if(other.CompareTag(CAR_COLLIDER))
        {
            
            finishPanel.SetActive(true);
        }
    }

}
