using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DefensiveAbility : MonoBehaviour
{
    private Animator anim;
    public GameObject sheild;
    private bool canActiveSheild = true;
    public static int returnedDamage;
    public static bool shieldActive = false;
    public GameObject grenadeObject;

    public Text defensiveAbilityCoolDownTimer;
    private int coolDownCounter = 15;

    IEnumerator waitTwoSeconds(){
        yield return new WaitForSeconds(1.5f);
        sheild.gameObject.SetActive(true);
        shieldActive = true;
        anim.SetBool("onDefClick", false);
    }
    IEnumerator waitFiveSeconds(){
        yield return new WaitForSeconds(5f);
        sheild.gameObject.SetActive(false);
        if(returnedDamage != 0)
        {
            //Insantiate
            GameObject cloneObject;
            cloneObject = Instantiate(grenadeObject, this.transform.position, this.transform.rotation);
            cloneObject.transform.Translate(Vector3.forward * 1.1f);
            cloneObject.transform.Translate(Vector3.up * 2f);


            cloneObject.tag = "Heavy";
            cloneObject.gameObject.GetComponent<Rigidbody>().velocity = this.transform.TransformDirection(Vector3.forward * 30);
            cloneObject.gameObject.GetComponent<def1Dmg>().returnDamage = returnedDamage;
            print("Total damage is " + cloneObject.gameObject.GetComponent<def1Dmg>().returnDamage);
        }
       

        shieldActive = false;
        returnedDamage = 0;
        canActiveSheild = false;
        StartCoroutine(waitFifteenSeconds());
        //anim.SetBool("onDefClick", false);
    }
    IEnumerator waitFifteenSeconds(){
        yield return new WaitForSeconds(15f);
        canActiveSheild = true;
    }

    void IncreaseCoolDown()
    {
        if(coolDownCounter < 15 && !shieldActive)
        {
            coolDownCounter += 1;
        }
    }

   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("IncreaseCoolDown", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(canActiveSheild)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                sheild.gameObject.SetActive(true);
                shieldActive = true;
                coolDownCounter = 0;
                StartCoroutine(waitFiveSeconds());
                
            }
        }

        defensiveAbilityCoolDownTimer.text = "Defensive ability CD timer: " + coolDownCounter;


    }
}
