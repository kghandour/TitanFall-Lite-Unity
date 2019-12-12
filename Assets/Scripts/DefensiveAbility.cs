using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveAbility : MonoBehaviour
{
    private Animator anim;
    public GameObject sheild;
    private bool canActiveSheild = true;
    public static int returnedDamage;
    public static bool shieldActive = false;
    public GameObject grenadeObject;

    IEnumerator waitTwoSeconds(){
        yield return new WaitForSeconds(1.5f);
        sheild.gameObject.SetActive(true);
        shieldActive = true;
        anim.SetBool("onDefClick", false);
    }
    IEnumerator waitFiveSeconds(){
        yield return new WaitForSeconds(5f);
        sheild.gameObject.SetActive(false);
        //Insantiate
        GameObject cloneObject;
        cloneObject = Instantiate(grenadeObject, this.transform.position, this.transform.rotation);
        cloneObject.transform.Translate(Vector3.forward * 1.1f);
        cloneObject.transform.Translate(Vector3.up * 2f);


        cloneObject.tag = "Heavy";
        cloneObject.gameObject.GetComponent<Rigidbody>().velocity = this.transform.TransformDirection(Vector3.forward * 30);
        cloneObject.gameObject.GetComponent<def1Dmg>().returnDamage = returnedDamage;
        print("Total damage is " + cloneObject.gameObject.GetComponent<def1Dmg>().returnDamage);

        shieldActive = false;
        returnedDamage = 0;

        //anim.SetBool("onDefClick", false);
    }
    IEnumerator waitFifteenSeconds(){
        yield return new WaitForSeconds(15f);
        canActiveSheild = true;
    }

   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
            StartCoroutine(waitFiveSeconds());
            canActiveSheild = false;
            StartCoroutine(waitFifteenSeconds());
            }
        }
        
    }
}
