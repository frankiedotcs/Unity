using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmo : MonoBehaviour {
    public int type;
    public AudioClip pickup;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Bullets>() != null
            && collider.gameObject.tag == "Bullet")
        {
            GetComponent<AudioSource>().PlayOneShot(pickup);
            collider.gameObject.GetComponent<Bullets>().PickUpItem(type);
        }
    }


}
