using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {


    public float moveSpeed = 50.0f; //the movement speed

    public float force = 10.0f;

    private CapsuleCollider collide; //the chracter controller for movment and physics


    void Start()
    {
        collide = GetComponent<CapsuleCollider>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float straffe = Input.GetAxis("Horizontal") * moveSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
