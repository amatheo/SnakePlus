using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private SnakePlayer snakePlayer;
    [SerializeField] private BodyManager bodyManager;
    [SerializeField] private InputActionReference attack;
    private void OnEnable()
    {
        attack.action.performed += OnAttack;
        
    }
    
    private void OnAttack(InputAction.CallbackContext obj)
    {
        bodyManager.AddModule(null);
    }
}
