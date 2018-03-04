using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Target : MonoBehaviour {
    public GameObject pop;
    
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            
            Instantiate(pop, transform.position, transform.rotation);
        }
            Destroy(gameObject);
        
    }
  
  
}
