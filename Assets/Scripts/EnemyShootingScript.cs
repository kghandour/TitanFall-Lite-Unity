using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{


    public GameObject shotStart;
    public PrimaryWeapons gun;


    private Animator anim;
    private Transform player;



    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (anim.GetBool("isFiring"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(shotStart.transform.position, shotStart.transform.forward, out hit, gun.range))
        {
            if (hit.transform.tag == "Player" && anim.GetBool("fireNow"))
            {
                if (DefensiveAbility.shieldActive)
                {
                    DefensiveAbility.returnedDamage += gun.damageAmount;
                }
                else
                {
                    health_and_call_titan_script playerHealth = hit.transform.gameObject.GetComponent<health_and_call_titan_script>();
                    TitanHealthAndDisembarkScript playerTitanHealth = hit.transform.gameObject.GetComponent<TitanHealthAndDisembarkScript>();
                    if (playerHealth != null)
                    {
                        playerHealth.hit(gun.damageAmount);
                        anim.SetBool("fireNow", false);
                    }
                    if(playerTitanHealth != null)
                    {
                        playerTitanHealth.hit(gun.damageAmount);
                        anim.SetBool("fireNow", false);
                    }
                }
            }
            //else
            //{
            //    Debug.Log("DIDN'T HIT");
            //}
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }


    //public float maxDamage = 120f;
    //public float minDamage = 45f;
    //public float flashIntensity = 3f;
    //public float fadeSpeed = 10f;

    //private Animator anim;
    //private LineRenderer laserShotLine;
    //private Light laserShotLight;
    //private SphereCollider col;
    //private Transform player;
    //private bool shooting;
    //private float scaledDamage;


    //private void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    laserShotLine = GetComponentInChildren<LineRenderer>();
    //    laserShotLight = laserShotLine.gameObject.GetComponent<Light>();
    //    col = GetComponent<SphereCollider>();
    //    player = GameObject.FindGameObjectWithTag("Player").transform;


    //    laserShotLine.enabled = false;
    //    laserShotLight.intensity = 0;

    //    scaledDamage = maxDamage - minDamage;
    //}

    //private void Update()
    //{
    //    if (anim.GetBool("isFiring"))
    //    {
    //        Shoot(); 
    //    }
    //    else
    //    {
    //        laserShotLine.enabled = false;
    //    }

    //    laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
    //}

    //private void OnAnimatorIK(int layerIndex)
    //{
    //}

    //void Shoot()
    //{
    //    float fractionalDistance = (col.radius - Vector3.Distance(transform.position, player.position)) / col.radius;
    //    float damage = scaledDamage * fractionalDistance + minDamage;
    //}

    //void ShotEffects()
    //{
    //    laserShotLine.SetPosition(0, laserShotLine.transform.position);
    //    laserShotLine.SetPosition(1, player.position + Vector3.up * 1.5f);
    //    laserShotLine.enabled = false;
    //    laserShotLight.intensity = flashIntensity;
    //}


}
