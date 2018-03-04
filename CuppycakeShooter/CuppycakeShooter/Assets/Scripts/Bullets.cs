using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    
    private Ammo ammo;
    // Use this for initialization
    void Start () {
        ammo = GetComponent<Ammo>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void pickupCakeAmmo()
    {
        ammo.AddAmmo(Constants.Cake, 13);
        Debug.Log("A baker's dozen was added to your ammo!");
    }

    private void pickupBeerAmmo()
    {
        ammo.AddAmmo(Constants.BeerBottle, 6);
        Debug.Log("A six-pack was added to your ammo!");
    }

    private void pickupPigAmmo()
    {
        ammo.AddAmmo(Constants.PigBullet, 1);
        Debug.Log("A pig was added to your ammo!");
    }

    

    public void PickUpItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.CakeAmmo:
                pickupCakeAmmo();
                break;
            case Constants.Beer:
                 pickupBeerAmmo();
                break;
            case Constants.Pig:
                pickupPigAmmo();
                break;
            default:
                Debug.LogError("Bad pickup type passed: " + pickupType);
                break;

        }
    }
}
