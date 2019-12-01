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
                if (Stats.titanFall <= 100)
                {
                    if (collision.gameObject.CompareTag("enemyPilot"))
                    {
                        Stats.titanFall += 10;
                    }
                    else if (collision.gameObject.CompareTag("enemyTitan"))
                    {
                        Stats.titanFall += 50;
                    }
                    print("Titanfall " + Stats.titanFall);
                    
                }
                collision.gameObject.SetActive(false);
            }

        }
        if (!collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

}
