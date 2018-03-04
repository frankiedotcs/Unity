using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : FireBullets {
    
    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButton(0))
        {
            Fire();
            
        }
    }
}
