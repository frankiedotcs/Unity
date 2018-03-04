using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    private Ammo ammo;
    private FireBullets bulletType;
    public Rigidbody cakeAmmo;
    public Rigidbody beerAmmo;
    public Rigidbody pigAmmo;

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(ray.direction);
        bulletType.bulletType = Instantiate(cakeAmmo, transform.position, rotation) as Rigidbody;
        Debug.Log("A baker's dozen was added to your ammo!");
    }

    private void pickupBeerAmmo()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(ray.direction);
        bulletType.bulletType = Instantiate(beerAmmo, transform.position, rotation) as Rigidbody;
        Debug.Log("A six-pack was added to your ammo!");
        
    }

    private void pickupPigAmmo()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(ray.direction);
        bulletType.bulletType = Instantiate(pigAmmo, transform.position, rotation) as Rigidbody;
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