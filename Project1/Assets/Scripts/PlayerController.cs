using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// player controller script
/// Liz "Frankie" Ruttenbur
/// </summary>

public class PlayerController : MonoBehaviour {
    /// <summary>
    /// public variables
    /// </summary>
    public float moveSpeed = 50.0f; //the movement speed
    public Rigidbody head; //controls the head
    public LayerMask layerMask; //the layer mask for the ray
    /// <summary>
    /// private variables
    /// </summary>
    private CharacterController characterController; //the chracter controller for movment and physics
    private Vector3 currentLookTarget = Vector3.zero; //for the ray


    // Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(moveDirection * moveSpeed);
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

        }
        else
        {
            head.AddForce(transform.right * 150, ForceMode.Acceleration); //adds force to the head
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        if(Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {
            //gets target position for the space marine
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            //used to determine the marines rotation which turns the marine
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
            //makes the actual turn
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
        }
    }

    
}
