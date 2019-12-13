using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoreAbility : MonoBehaviour
{
    private Animator anim;
    public GameObject Laser;
    public static int canActiveLaser = 0;
    public Slider coreAbilityMeterBar;

    public AudioSource source;
    public AudioClip abilitySound;
    // Start is called before the first frame update

    IEnumerator waitThreeSeconds(){
        yield return new WaitForSeconds(3f);
        Laser.gameObject.SetActive(false);
        anim.SetBool("onCoreClick", false);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        Laser.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(canActiveLaser == 100)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                anim.SetBool("onCoreClick", true);
                Laser.gameObject.SetActive(true);
                source.clip = abilitySound;
                source.Play();
                StartCoroutine(waitThreeSeconds());
                canActiveLaser = 0;
            }
        }
        coreAbilityMeterBar.value = canActiveLaser;
    }
}
