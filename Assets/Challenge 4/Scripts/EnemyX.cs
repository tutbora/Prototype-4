﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX ratioSpeed;
    private float ratio;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        ratio = GameObject.Find("Spawn Manager X").GetComponent<SpawnManagerX>().RatioSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there        
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        
        enemyRb.AddForce(lookDirection * ratio);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}