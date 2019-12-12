using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit,100))
        {
            if(hit.collider)
            {
                print("hitting target " + hit.transform.tag);
                if(hit.transform.tag == "enemyTitan")
                {
                    calculateDamage(hit.collider.gameObject, hit.collider.gameObject.GetComponent<HealthScript>(), "enemyTitan");
                }
                if (hit.transform.tag == "enemyPilot")
                {
                    calculateDamage(hit.collider.gameObject, hit.collider.gameObject.GetComponent<HealthScript>(), "enemyPilot");
                }
                lr.SetPosition(1,hit.point);
            }
        }
        else 
        {
            lr.SetPosition(1, transform.forward*5000);
        }
    }

    void calculateDamage(GameObject enemy, HealthScript enemyHealth, string enemyType)
    {
        if (enemyHealth != null)
        {
            enemyHealth.currentHealth -= 500;
            if (enemyHealth.currentHealth <= 0 && !enemy.GetComponent<Animator>().GetBool("isDead"))
            {
                //if (health_and_call_titan_script.titanfallMeter <= 100)
                //{
                //    if (enemyType == "enemyPilot")
                //    {
                //        health_and_call_titan_script.titanfallMeter += 10;
                //    }
                //    else if (enemyType == "enemyTitan")
                //    {
                //        health_and_call_titan_script.titanfallMeter += 50;
                //    }
                //}

                //if (health_and_call_titan_script.titanfallMeter > 100)
                //{
                //    health_and_call_titan_script.titanfallMeter = 100;
                //}
                //print("Titanfall " + health_and_call_titan_script.titanfallMeter);
                enemy.GetComponent<Animator>().SetBool("isDead", true);
            }

        }
    }
}
