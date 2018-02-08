using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// player controller script
/// Liz "Frankie" Ruttenbur
/// </summary>

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// public variables
    /// </summary>
    public float moveSpeed = 50.0f; //the movement speed
    public Rigidbody head; //controls the head
    public LayerMask layerMask; //the layer mask for the ray
    public Animator bodyAnimator;
    public float[] hitForce;
    public float timeBetweenHits = 2.5f;
    /// <summary>
    /// private variables
    /// </summary>
    private CharacterController characterController; //the chracter controller for movment and physics
    //private Vector3 currentLookTarget = Vector3.zero; //for the ray
    private bool isHit = false;
    private float timeSinceHit = 0;
    private int hitNumber = -1;


    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(moveDirection * moveSpeed);

        if (isHit)
        {
            timeSinceHit += Time.deltaTime;
            if (timeSinceHit > timeBetweenHits)
            {
                isHit = false;
                timeSinceHit = 0;
            }
        }
    }
    /// <summary>
    /// Called at consistent intervals
    /// Rigidbody stuff needs to go into this function
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));

        if (moveDirection == Vector3.zero)
        {
            bodyAnimator.SetBool("IsMoving", false);//sets the animator for the legs
        }
        else
        {
            head.AddForce(transform.right * 150, ForceMode.Acceleration); //adds force to the head
            bodyAnimator.SetBool("IsMoving", true); //sets the animator for the legs
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {
            //gets target position for the space marine
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            //used to determine the marines rotation which turns the marine
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
            //makes the actual turn
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Alien alien = other.gameObject.GetComponent<Alien>();
        if (alien != null)
        {
            //checks to see if the colliding object has the alien script attatched to it
            if (!isHit)
            {//hitNumber increases by one after you get a reference to CameraShake()
                hitNumber += 1;
                CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
                if (hitNumber < hitForce.Length)
                {   //Space Marine is still alive
                    cameraShake.intensity = hitForce[hitNumber];
                    cameraShake.Shake();
                }
                else
                {
                    //DEATH
                }
                isHit = true;
                //play sound effect
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.hurt);
            }
            alien.Die();
        }
    }
}



