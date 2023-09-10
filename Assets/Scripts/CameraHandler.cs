using System.Collections;
using System.Collections.Generic;


//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraHandler : MonoBehaviour
{
    [SerializeField] GameObject carLocation;
    [Header("Behaviour: only rotate around Y")]
    [SerializeField] float rotatingSpeed = 5f;
    float rotatingDirection;
    [SerializeField] Vector2 initialTouch;
    [SerializeField] Vector2 newPosition;
    [SerializeField] Vector2 dir;
    // 
    // different camera behaviour
    [Header("Behaviour: arbitrary rotating")]
    [SerializeField] float distance = 20;
    float rotationY = -69, rotationX = 14;
    [SerializeField] float sensitivity = 0.2f;
    [SerializeField] float lowerThreshold = 1f;
    [SerializeField] float upperThreshold = 89;
    Vector3 currVelocity = Vector3.zero;
    Vector3 currentRotation;
    [SerializeField] float smoothTime = 3;
    [SerializeField] float maxSpeed = 100f;
    
    private void Start() {
       
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            //Debug.Log("Get touch" + Input.GetTouch(0).deltaPosition);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                initialTouch = touch.position;
                //Debug.Log("initial touch" + initialTouch);
            }
            else if (touch.phase == UnityEngine.TouchPhase.Moved)
            {
                
                Vector2 touchDeltaPosition = touch.deltaPosition;
                //Vector2 deltaScaled = new Vector2(touchDeltaPosition.x / Screen.width, touchDeltaPosition.y / Screen.height);
                //Debug.Log("delta: " + deltaScaled);    
                rotationY += touchDeltaPosition.x  * sensitivity * Time.deltaTime;
                rotationX -= touchDeltaPosition.y  * sensitivity * Time.deltaTime;
                rotationX = Mathf.Clamp(rotationX, lowerThreshold, upperThreshold);
                //Debug.Log(rotationX + " rotation X ");
               
                
                // transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles,
                // targetRotation, smoothTime);
                //transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, targetRotation, smoothTime);
                // transform.localEulerAngles = Vector3.SmoothDamp(transform.localEulerAngles, targetRotation,
                //   ref currVelocity, smoothTime); 
                //RotateAroundY(touch);
                
            }
            else if(touch.phase == UnityEngine.TouchPhase.Ended)
            {
                
                //rotatingDirection = 0;
            } 
            
            
        }
        Vector3 targetRotation = new Vector3(rotationX, rotationY, 0);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation,
        ref currVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

    }

    private void RotateAroundY(Touch touch)
    {
        Debug.Log("Moved ");
        newPosition = touch.position;
        dir = (newPosition - initialTouch).normalized;
        rotatingDirection = dir.x > 0.2 ? 1 : dir.x < -0.2 ? -1 : 0;
        Debug.Log("Dir" + dir);
        Debug.Log($"Initial touch {initialTouch}, new touch {newPosition}");
    }

    private void LateUpdate() {
        transform.position = carLocation.transform.position - transform.forward * distance;
        
        
        // rotate aroundY
        //transform.LookAt(carLocation.transform);
        //transform.RotateAround(carLocation.transform.position, Vector3.up, rotatingDirection * rotatingSpeed * Time.deltaTime);
    }
}
