using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 50.0f; //the movement speed
    public LayerMask layerMask; //the layer mask for the ray
    public float force = 10.0f;


    /// <summary>
    /// private variables
    /// </summary>
    private CharacterController characterController; //the chracter controller for movment and physics
                                                     //private Vector3 currentLookTarget = Vector3.zero; //for the ray




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
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {
            //gets target position for the player
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            //used to determine the players rotation
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
            //makes the actual turn
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
        }
        if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {
            //gets target position for the player
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            //used to determine the players Rotation
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
            //makes the actual turn
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
        }
    }
}