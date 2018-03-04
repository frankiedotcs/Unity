using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    private Ammo ammo;
    private FireBullets bulletType;
    public Rigidbody cakeAmmo;
    public Rigidbody beerAmmo;
    public Rigidbody pigAmmo;
    Gun bullets;

    [SerializeField]
    public AudioClip popping;
    // Use this for initialization
    void Start()
    {
        ammo = GetComponent<Ammo>();
        bulletType = GetComponent<FireBullets>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void pickupCakeAmmo()
    {
        
        Debug.Log("A baker's dozen was added to your ammo!");
    }

    private void pickupBeerAmmo()
    {

        
        Debug.Log("A six-pack was added to your ammo!");

    }

    private void pickupPigAmmo()
    {
        
        Debug.Log("A pig was added to your ammo!");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Target"))
        {
            GetComponent<AudioSource>().PlayOneShot(popping);

        }

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