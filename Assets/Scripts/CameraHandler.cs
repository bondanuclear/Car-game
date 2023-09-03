using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraHandler : MonoBehaviour
{
    [SerializeField] GameObject carLocation;
    [SerializeField] float rotatingSpeed = 5f;
    float rotatingDirection;
    [SerializeField] Vector2 initialTouch;
    [SerializeField] Vector2 newPosition;
    [SerializeField] Vector2 dir;
 
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
                //Debug.Log("Moved ");
                newPosition = touch.position;
                dir = (newPosition - initialTouch).normalized;
                rotatingDirection = dir.x > 0.2 ? 1 : dir.x < -0.2 ? -1 : 0;
                //Debug.Log("Dir" + dir);
                //Debug.Log($"Initial touch {initialTouch}, new touch {newPosition}");
            }
            else if(touch.phase == UnityEngine.TouchPhase.Ended)
            {
                rotatingDirection = 0;
            }

        }
       
        
    }
    private void LateUpdate() {
        transform.LookAt(carLocation.transform);
        transform.RotateAround(carLocation.transform.position, Vector3.up, rotatingDirection * rotatingSpeed * Time.deltaTime);
    }
}
