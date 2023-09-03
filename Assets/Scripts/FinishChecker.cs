using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;
    private void OnTriggerEnter(Collider other) {
        //Debug.Log($"Triggered by {other.gameObject.tag}");
        if(other.CompareTag("CarBody"))
        {
            Debug.Log("Touched a player");
            finishPanel.SetActive(true);
        }
    }

}
