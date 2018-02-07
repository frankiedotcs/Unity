﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour {

    /// <summary>
    /// public variables
    /// </summary>
    /// 
    public Transform target;
    public float navigationUpdate;

    /// <summary>
    /// private variables
    /// </summary>
    private NavMeshAgent agent;
    private float navigationTime = 0;
	
    // Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
        agent.destination = target.position;

        if (navigationTime > navigationUpdate)
        {
            agent.destination = target.position;
            navigationTime = 0;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);

    }
}
