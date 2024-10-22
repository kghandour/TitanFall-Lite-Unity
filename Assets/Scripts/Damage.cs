﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //EnemyStats enemyStats;
    private HealthScript enemyHealth;
    private Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        enemyHealth = collision.gameObject.GetComponent<HealthScript>();
        enemyAnim = collision.gameObject.GetComponent<Animator>();
        if (enemyHealth != null)
        {
            enemyHealth.currentHealth -= WeaponManager.damageAmount;

            if (enemyAnim != null)
            {
                enemyAnim.SetBool("Hit", true);
                print(enemyAnim.GetBool("Hit"));
            }

            if (enemyHealth.currentHealth <= 0 && !enemyAnim.GetBool("isDead"))
            {
                if (health_and_call_titan_script.titanfallMeter <= 100)
                {
                    if (collision.gameObject.CompareTag("enemyPilot"))
                    {
                        health_and_call_titan_script.titanfallMeter += 10;
                        print("Impact pilot");
                    }
                    else if (collision.gameObject.CompareTag("enemyTitan"))
                    {
                        health_and_call_titan_script.titanfallMeter += 50;
                        print("impact enemyTitan");
                    }
                    
                }

                if (health_and_call_titan_script.titanfallMeter > 100)
                {
                    health_and_call_titan_script.titanfallMeter = 100;
                }
                print("Titanfall " + health_and_call_titan_script.titanfallMeter);

                enemyAnim.SetBool("isDead", true);
                //Destroy(collision.gameObject);
            }

        }

        

        if (!collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

}
