using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    EnemyStats enemyStats;
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
        enemyStats = collision.gameObject.GetComponent<EnemyStats>();
        if (enemyStats != null)
        {
            enemyStats.health -= WeaponManager.damageAmount;
            if (enemyStats.health <= 0)
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

                collision.gameObject.SetActive(false);
            }

        }
        if (!collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

}
