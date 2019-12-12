using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAreaDamage : MonoBehaviour
{
    HealthScript enemyHealth;
    Animator enemyAnim;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if(currentTime - startTime >= 3)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        enemyHealth = collision.gameObject.GetComponent<HealthScript>();
        enemyAnim = collision.gameObject.GetComponent<Animator>();
        if (enemyHealth != null)
        {
            enemyHealth.currentHealth -= 50;

            if (enemyAnim != null)
            {
                enemyAnim.SetBool("Hit", true);
                print(enemyAnim.GetBool("Hit"));
            }

            if (enemyHealth.currentHealth <= 0 && !enemyAnim.GetBool("isDead"))
            {
                if (CoreAbility2.canActiveFlame <= 100)
                {
                    if (collision.gameObject.CompareTag("enemyPilot"))
                    {
                        CoreAbility2.canActiveFlame += 10;
                        print("Impact pilot");
                    }
                    else if (collision.gameObject.CompareTag("enemyTitan"))
                    {
                        CoreAbility2.canActiveFlame += 50;
                        print("impact enemyTitan");
                    }

                }

                if (CoreAbility2.canActiveFlame > 100)
                {
                    CoreAbility2.canActiveFlame = 100;
                }

                enemyAnim.SetBool("isDead", true);
                //Destroy(collision.gameObject);
            }

        }
    }
}
