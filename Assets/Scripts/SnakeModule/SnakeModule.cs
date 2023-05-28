using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class SnakeModule : MonoBehaviour
{
    
    [SerializeField] protected Rigidbody2D rigidbody2d;
    [SerializeField] protected float cooldown;
    
    public Rigidbody2D Rigidbody2D => rigidbody2d;
    
    protected float tryFireTime = 0;

    protected abstract bool UseModule(SnakePlayer player);
    
    public bool TryModule(SnakePlayer player)
    {
        if (Time.time <= tryFireTime)
        {
            return false;
        }
        tryFireTime = Time.time + cooldown;
        return UseModule(player);
        
    }
    
}
