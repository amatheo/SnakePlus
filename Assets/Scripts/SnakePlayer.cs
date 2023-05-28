using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakePlayer : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigidbody2d;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private InputActionReference movement, pointer;
    
    
    [SerializeField] Vector2 _velocity = Vector2.up;
    
    private void Update()
    {
        // Rotate velocity based on left right input
        Vector2 movementVector2 = movement.action.ReadValue<Vector2>();
        _velocity = Quaternion.Euler(0, 0, -movementVector2.x * turnSpeed) * _velocity;
    }

    private void FixedUpdate()
    {
        // Move rigidbody
        // It seem that a bigger speed value makes the fps better, probably because the multiplication is done with less digits
        rigidbody2d.MovePosition(rigidbody2d.position + _velocity * (speed * Time.deltaTime));
    }
}
