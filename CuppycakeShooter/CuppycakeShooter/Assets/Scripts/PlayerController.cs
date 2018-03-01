using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 100; //speed for the movement of player
    public float tilt; //the tilt for the player movement
    private Rigidbody rb; //rigid body component
    public GameObject shot; //the shot
    public Transform shotSpawn; //the transform position of the shot

    public float fireRate;
    private float nextFire;
    public bool rapidFire = false;
    public float fastFire;
    private float upgradeTime = 10f;
    public int upgradesLeft = 2;
    public bool quickMove;
    private float currentRapidFireTime = 0.0f;
    private float holdPress;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime *speed; //the movement captures
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Rotate(0, moveHorizontal, 0);
        transform.Translate(0, 0, moveVertical);
    }

   
}
