using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAt : MonoBehaviour {

    public Rigidbody cake;
    public Rigidbody bullet;
    public float velocity = 10.0f;
    public ForceMode forceMode;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Input.GetMouseButtonDown(0))
        {
            
            Rigidbody instance = Instantiate(cake, transform.position, transform.rotation) as Rigidbody;
            //instance.velocity = transform.parent.forward * 100;
            instance.velocity = transform.forward * velocity;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Rigidbody instance = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            instance.AddForce(transform.forward * velocity, forceMode);
            //instance.velocity = transform.parent.forward * 100;
        }   
	}

  
}
