using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] GameObject carLocation;
    [SerializeField] float rotatingSpeed = 5f;
    float rotatingDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.A)) rotatingDirection = 1;
        else if (Input.GetKey(KeyCode.D)) rotatingDirection = -1;
        else rotatingDirection = 0;
        
    }
    private void LateUpdate() {
        transform.LookAt(carLocation.transform);
        transform.RotateAround(carLocation.transform.position, Vector3.up, rotatingDirection * rotatingSpeed * Time.deltaTime);
    }
}
