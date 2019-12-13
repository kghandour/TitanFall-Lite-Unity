using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalTouch : MonoBehaviour
{
    HealthScript enemyHealth;
    Animator enemyAnim;
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
        print("touching someone");
        enemyHealth = collision.gameObject.GetComponent<HealthScript>();
        enemyAnim = collision.gameObject.GetComponent<Animator>();
        if (enemyHealth != null)
        {
            enemyHealth.currentHealth -= 80;

            if (enemyAnim != null)
            {
                enemyAnim.SetBool("Hit", true);
                print(enemyAnim.GetBool("Hit"));
            }

            if (enemyHealth.currentHealth <= 0 && !enemyAnim.GetBool("isDead"))
            {
                print("Titanfall " + health_and_call_titan_script.titanfallMeter);

                enemyAnim.SetBool("isDead", true);
                //Destroy(collision.gameObject);
            }

        }

    }
}