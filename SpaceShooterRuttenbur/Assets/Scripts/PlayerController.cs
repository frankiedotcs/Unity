using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// New public boundary class
/// that holds values for position for boundaries
/// </summary>
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
/// <summary>
/// Player Controller to handle player movement and firing for
/// the space shooter game
/// Liz "Frankie" Ruttenbur
/// </summary>
public class PlayerController : MonoBehaviour {

    public float speed = 100; //speed for the movement of player
    public Boundary boundary; //the boundary class so you can use the boundary variables in this class
    public float tilt; //the tilt for the player movement
    private Rigidbody rb; //rigid body component
    public GameObject shot; //the shot
    public Transform shotSpawn; //the transform position of the shot
    public float fireRate;
    private float nextFire;

    /// <summary>
    /// start gets the rigidbody component and sets it to rb
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    /// <summary>
    /// the update function sets the fire rate and the spawn shot stuff
    /// plays the audio
    /// </summary>
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    /// <summary>
    /// Update is called once per frame
    ///handles the physics
    ///</summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //the movement captures
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = movement * speed;
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

   
}
