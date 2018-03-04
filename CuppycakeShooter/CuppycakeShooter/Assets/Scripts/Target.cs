using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Target : MonoBehaviour {
    public GameObject pop;
    [SerializeField]
    public AudioClip popping;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
       
            GetComponent<AudioSource>().PlayOneShot(popping);
            Instantiate(pop, transform.position, transform.rotation);
            Destroy(gameObject);
        
    }
    //void OnTriggerEnter(Collider collider)
    //{

    //    GetComponent<AudioSource>().PlayOneShot(popping);

    //    if (collider.gameObject.GetComponent<Bullets>() != null
    //      && collider.gameObject.tag == "Bullet")
    //    {
    //        Instantiate(pop, transform.position, transform.rotation);

           
    //    }
    //    Destroy(gameObject);

    //}
  
}
