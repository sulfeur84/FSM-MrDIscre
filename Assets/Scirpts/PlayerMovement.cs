using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float CrouchSpeed = 2f;

    public Rigidbody rb;

    private Vector3 movement;

    private void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)) MoveSpeed = CrouchSpeed;
        else MoveSpeed = 5f;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
