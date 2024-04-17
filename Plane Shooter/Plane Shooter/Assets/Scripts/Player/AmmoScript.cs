using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : Ammo
{
    public override void MoveSpeed()
    {
       velocity = direction * speed;
    }
}
