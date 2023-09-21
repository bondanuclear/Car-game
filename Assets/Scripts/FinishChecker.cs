using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    const string CAR_COLLIDER = "CarBody";
    public static event Action OnFinishPassed;
    private void OnTriggerEnter(Collider other) {
        //Debug.Log($"Triggered by {other.gameObject.tag}");
        if(other.CompareTag(CAR_COLLIDER))
        {
            
            //finishPanel.SetActive(true);
            OnFinishPassed?.Invoke();
        }
    }

}
