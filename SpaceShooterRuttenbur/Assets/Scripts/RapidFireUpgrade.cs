using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireUpgrade : MonoBehaviour {

    public GameObject player;
    public PlayerController playerController;

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
            playerController.rapidFire = true;
        }
    }
}
