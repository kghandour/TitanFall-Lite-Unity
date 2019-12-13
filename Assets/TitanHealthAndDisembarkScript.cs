using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitanHealthAndDisembarkScript : MonoBehaviour
{

    public int health = 400;
    public Slider healthBar;

    public bool titanDeployed;
    public GameObject Titan;
    public GameObject Pilot;
    public GameObject TitanPlayer;
    public GameObject secondaryCamera; //used as an effect for dimming the screen at embark time

    public AudioSource hitSource;
    public AudioSource bulletSource;

    public AudioClip bulletHitSound;
    public AudioClip hitSound;

    public int invincible = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator Disembark()
    {
        secondaryCamera.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        secondaryCamera.SetActive(false);

        health = 400;
        CoreAbility.canActiveLaser = 0;
        Pilot.GetComponent<health_and_call_titan_script>().titanDeployed = false;
        Pilot.transform.position = TitanPlayer.transform.position;
        TitanPlayer.SetActive(false);
        Pilot.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        if (Input.GetKeyDown("e") || health <= 0)
        {
            StartCoroutine(Disembark());
        }
    }

    public void hit(int damage)
    {
        bulletSource.PlayOneShot(bulletHitSound);

        if (invincible <= 0)
        {
            hitSource.PlayOneShot(hitSound);
            health -= damage;
        }
    }
}
