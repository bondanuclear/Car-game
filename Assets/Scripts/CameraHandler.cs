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
    float rotationY, rotationX;
    [SerializeField] float sensitivity = 0.2f;
    [SerializeField] float lowerThreshold = 1f;
    [SerializeField] float upperThreshold = 89;

    private void Start() {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
           
            //Debug.Log(touch.position);
            if(touch.phase == UnityEngine.TouchPhase.Began)
            {
                initialTouch = touch.position;
                //Debug.Log("initial touch" + initialTouch);
            }
            else if (touch.phase == UnityEngine.TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition.normalized;
                //Debug.Log(touchDeltaPosition);
                rotationY += touchDeltaPosition.x * sensitivity * Time.deltaTime;
                rotationX += touchDeltaPosition.y * sensitivity * Time.deltaTime;
                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
                //RotateAroundY(touch);
            }
            else if(touch.phase == UnityEngine.TouchPhase.Ended)
            {
                //rotatingDirection = 0;
            }

        }
       
        
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
        rotationX = Mathf.Clamp(rotationX, lowerThreshold, upperThreshold);
        
        // rotate aroundY
        //transform.LookAt(carLocation.transform);
        //transform.RotateAround(carLocation.transform.position, Vector3.up, rotatingDirection * rotatingSpeed * Time.deltaTime);
    }
}
