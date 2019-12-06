using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;


    public GameObject shotStart;


    private Animator anim;
    private Transform player;


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log("7aa7aa");
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
        //Debug.DrawRay(shotStart.transform.position, shotStart.transform.forward, Color.red, 30.0f, true);
        //Debug.Log("7aa7aa");
        if (Physics.Raycast(shotStart.transform.position, shotStart.transform.forward, out hit, range))
        {
            if (hit.transform.name == "FPSController")
                Debug.Log(hit.transform.name);
            //else
            //{
            //    Debug.Log("DIDN'T HIT");
            //}
        }
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
