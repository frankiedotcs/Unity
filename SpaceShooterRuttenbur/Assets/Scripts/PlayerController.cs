using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
/// 

public class PlayerController : MonoBehaviour {
    public Text upgradeText;
    public float speed = 100; //speed for the movement of player
    public Boundary boundary; //the boundary class so you can use the boundary variables in this class
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

    /// <summary>
    /// start gets the rigidbody component and sets it to rb
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
 
    void Update()
    {
        if (rapidFire)
        {
            fireRate = 0.1f;
            upgradeText.text = "RAPID FIRE ENABLED!";
        }
        else if (quickMove)
        {
            speed = 20f;
            upgradeText.text = "SPEED INCREASED!";
        }
        else if (rapidFire && quickMove)
        {
            upgradeText.text = "RAPID FIRE ENABLED AND SPEED INCREASED!";
        }

        if (!rapidFire)
        {
            currentRapidFireTime = 0.0f;
        }

        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {

            holdPress += Time.deltaTime;

            
            if (holdPress >= 3.0f && upgradesLeft != 0)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                upgradesLeft--;
                holdPress = 0.0f;
               
            }
            else
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }

           
        }

        
        if (currentRapidFireTime >= upgradeTime && rapidFire)
        {
            fireRate = 0.25f;
            currentRapidFireTime = 0.0f;
            rapidFire = false;
            upgradeText.text = "";

            
        }
      

        currentRapidFireTime += Time.deltaTime;
       
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
