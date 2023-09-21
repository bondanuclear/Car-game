using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    const string CAR_COLLIDER = "CarBody";
    public static event Action OnFinishPassed;
    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag(CAR_COLLIDER))
        {
            Debug.Log($"Triggered by {other.gameObject.tag}");
            //finishPanel.SetActive(true);
            OnFinishPassed?.Invoke();
        }
    }

}
