using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan1Dmg : MonoBehaviour
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

        enemyHealth = collision.gameObject.GetComponent<HealthScript>();
        enemyAnim = collision.gameObject.GetComponent<Animator>();
        if (enemyHealth != null)
        {
            enemyHealth.currentHealth -= 70;

            if (enemyAnim != null)
            {
                enemyAnim.SetBool("Hit", true);
                print(enemyAnim.GetBool("Hit"));
            }

            if (enemyHealth.currentHealth <= 0 && !enemyAnim.GetBool("isDead"))
            {
                if (CoreAbility.canActiveLaser <= 100)
                {
                    if (collision.gameObject.CompareTag("enemyPilot"))
                    {
                        CoreAbility.canActiveLaser += 10;
                        print("Impact pilot");
                    }
                    else if (collision.gameObject.CompareTag("enemyTitan"))
                    {
                        CoreAbility.canActiveLaser += 50;
                        print("impact enemyTitan");
                    }

                }

                if (CoreAbility.canActiveLaser > 100)
                {
                    CoreAbility.canActiveLaser = 100;
                }
                //print("Titanfall " + health_and_call_titan_script.titanfallMeter);

                enemyAnim.SetBool("isDead", true);
            }

        }
        Destroy(gameObject);

    }
}
