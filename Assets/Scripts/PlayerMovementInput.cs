using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementInput: MonoBehaviour
{
    
    [SerializeField] private InputActionReference movement, pointer;
    
    private Vector2 _movementVector2;
    private Vector2 _pointerVector2;

    public Vector2 MovementVector2
    {
        get => _movementVector2;
        set => _movementVector2 = value;
    }

    public Vector2 PointerVector2
    {
        get => _pointerVector2;
        set => _pointerVector2 = value;
    }

    // Update is called once per frame
    void Update()
    {
        _movementVector2 = movement.action.ReadValue<Vector2>();
        _pointerVector2 = GetPointerInput();
    }
    
    
    private Vector2 GetPointerInput()
    {
        Vector2 mousePos = pointer.action.ReadValue<Vector2>();
        return mousePos;
    }
}
