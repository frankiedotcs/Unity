using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAt : MonoBehaviour {
    public Rigidbody cake;
    public Rigidbody bullet;
    public float force = 10.0f;
    public ForceMode forceMode;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody instance = Instantiate(cake, transform.position, transform.rotation) as Rigidbody;
            instance.AddForce(transform.forward * force, forceMode);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Rigidbody instance = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            instance.AddForce(transform.forward * force, forceMode);
        }
	}
}
