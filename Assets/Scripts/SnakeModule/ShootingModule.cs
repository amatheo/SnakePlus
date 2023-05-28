using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModule : SnakeModule
{
    protected override bool UseModule(SnakePlayer player)
    {
        Debug.Log("pew pew");
        return true;
    }
}
