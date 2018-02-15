using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementUpgrade : MonoBehaviour
{

    public GameObject player;
    public PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            playerController.quickMove = true;
        }
    }
}
