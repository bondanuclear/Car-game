using System.Collections;
using System.Collections.Generic;


//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraHandler : MonoBehaviour
{
    [SerializeField] GameObject carLocation;  

    [Header("Behaviour: arbitrary rotating")]
    [SerializeField] float distance = 20;
    float rotationY = -69, rotationX = 14;
    [SerializeField] float sensitivity = 0.2f;
    [SerializeField] float lowerThreshold = 1f;
    [SerializeField] float upperThreshold = 89;
    Vector3 currVelocity = Vector3.zero;
    [SerializeField] Vector3 currentRotation = new Vector3(14, -69, 0);
    [SerializeField] float smoothTime = 3;
    public bool canRotate = false;
    void Update()
    {
        if(!canRotate) return;
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            
            
            if (touch.phase == UnityEngine.TouchPhase.Moved)
            {
                
                Vector2 touchDeltaPosition = touch.deltaPosition;
                //Vector2 deltaScaled = new Vector2(touchDeltaPosition.x / Screen.width, touchDeltaPosition.y / Screen.height);
                   
                rotationY += touchDeltaPosition.x  * sensitivity * Time.deltaTime;
                rotationX -= touchDeltaPosition.y  * sensitivity * Time.deltaTime;
                rotationX = Mathf.Clamp(rotationX, lowerThreshold, upperThreshold);
                 
                
                
            }
           
            
            
        }
        Vector3 targetRotation = new Vector3(rotationX, rotationY, 0);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation,
        ref currVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

    }

    

    private void LateUpdate() {
        transform.position = carLocation.transform.position - transform.forward * distance;
        
        
        
    }
}
