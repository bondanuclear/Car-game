using System;
using System.Collections;
using System.Collections.Generic;


//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraHandler : MonoBehaviour
{
    [SerializeField] GameObject carLocation;  

    [Header("Behaviour: arbitrary rotating")]
    [SerializeField] Vector3 initialCameraPos;
    [SerializeField] float distance = 20;
    float rotationY = -69, rotationX = 14;
    [SerializeField] float sensitivity = 0.2f;
    [SerializeField] float lowerThreshold = 1f;
    [SerializeField] float upperThreshold = 89;
    Vector3 currVelocity = Vector3.zero;
    [SerializeField] Vector3 currentRotation = new Vector3(14, -69, 0);
    [SerializeField] float smoothTime = 3;
    Vector3 targetRotation;
    private bool canRotate = false;
    bool isCalculated = false;

    private void OnEnable() {
        UIManager.OnPanelChanged += EnableCameraRotation;
    }
    private void OnDisable() {
        UIManager.OnPanelChanged -= EnableCameraRotation;
    }
    void Update()
    {
        if(!canRotate) 
        {
            if(!isCalculated)
            {
                float val = GetRemainder(currentRotation.y, 360);
                currentRotation.y = val > 0 ? -val : val;
                isCalculated = true;
            }
                
            Debug.Log(currentRotation.y);
            // Debug.Log("TEST " + (currentRotation.y - (360* (int)(currentRotation.y/360))));
            // Debug.Log(currentRotation);
            // Debug.Log("target rotation " + targetRotation);
            // Debug.Log(rotationY % 360);
            rotationX = initialCameraPos.x;
            rotationY = initialCameraPos.y;
            
        }
        else
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                isCalculated = false;
                
                
                if (touch.phase == UnityEngine.TouchPhase.Moved)
                {
                    
                    Vector2 touchDeltaPosition = touch.deltaPosition;
                    //Vector2 deltaScaled = new Vector2(touchDeltaPosition.x / Screen.width, touchDeltaPosition.y / Screen.height);
                    
                    rotationY += touchDeltaPosition.x  * sensitivity * Time.deltaTime;
                    rotationX -= touchDeltaPosition.y  * sensitivity * Time.deltaTime;
                    rotationX = Mathf.Clamp(rotationX, lowerThreshold, upperThreshold);
                    // if(rotationY >= 360) rotationY = 0;
                    // else if(rotationY <= -360) rotationY = 0;
                    
                    
                }
            
                
                
            }
        }
            targetRotation = new Vector3(rotationX, rotationY, 0);
            currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation,
            ref currVelocity, smoothTime);
            
            transform.localEulerAngles = currentRotation;
        
    }

    

    private void LateUpdate() {
        transform.position = carLocation.transform.position - transform.forward * distance;
        
        
        
    }
    void EnableCameraRotation(bool toActivate)
    {
        canRotate = toActivate;
        // if (!toActivate)
        // {
        //     StartCoroutine(ReturnCameraInitialPos(new Vector3(14, -69, 0)));
        // }
       
       
        

    }
    // does not work because of current rotation value;
    IEnumerator ReturnCameraInitialPos(Vector3 rotationVector)
    {
        float duration = 0.1f;
        float time = 0;
        
        while (time <= duration)
        {
            time += Time.deltaTime;
            float percent = Mathf.Clamp01(time/duration);
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, rotationVector,
            percent);
            
            yield return null;

        }

    }
    float GetRemainder(float a, float b)
    {
        return a - (b * (int)(a / b));
    }
}
