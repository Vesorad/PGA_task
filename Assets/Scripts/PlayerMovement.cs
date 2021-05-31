using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("to fill")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform parentCam;
    [Header("Parameters")]
    [SerializeField] private float speed=6;
    [SerializeField] private float turnSmoothTime = 0.1f;
    
    private float _turnSmoothVelocity;
    void Update()
    {
        Movement();
        RotationCam();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0,vertical).normalized;
        if (direction.magnitude >=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0,angle,0);
            
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
    private void RotationCam()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            parentCam.rotation = Quaternion.Euler(0,parentCam.eulerAngles.y-speed,0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            parentCam.rotation = Quaternion.Euler(0,parentCam.eulerAngles.y+speed,0);
        } 
    }
}
