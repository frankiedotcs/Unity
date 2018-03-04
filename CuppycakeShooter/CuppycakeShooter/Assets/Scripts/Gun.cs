using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : FireBullets
{

    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            FirePigBullets();
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            FireBeerBullets();
        }
       
    }
}
