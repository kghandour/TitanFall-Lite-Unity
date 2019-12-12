using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DefensiveAbility2 : MonoBehaviour
{
    private Animator anim;
    public GameObject thermalSheild;
    public static bool shieldActive = false;
    private bool canActiveSheild = true;


    public Text defensiveAbilityCoolDownTimer;
    private int coolDownCounter = 15;
    // Start is called before the first frame update
    IEnumerator waitEightSeconds(){

        yield return new WaitForSeconds(8f);
        
        thermalSheild.gameObject.SetActive(false);
        //anim.SetBool("onDefClick", false);

        shieldActive = false;
        canActiveSheild = false;
        StartCoroutine(waitFifteenSeconds());
    }
    IEnumerator waitFifteenSeconds(){
        yield return new WaitForSeconds(15f);
        canActiveSheild = true;
    }

    void IncreaseCoolDown()
    {
        if (coolDownCounter < 15 && !shieldActive)
        {
            coolDownCounter += 1;
            print(coolDownCounter);
        }
    }




    void Start()
    {
        InvokeRepeating("IncreaseCoolDown", 0, 1f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canActiveSheild)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                thermalSheild.gameObject.SetActive(true);
                shieldActive = true;
                coolDownCounter = 0;
                StartCoroutine(waitEightSeconds());
            }
        }
        defensiveAbilityCoolDownTimer.text = "Defensive ability CD timer: " + coolDownCounter;
    }
}
