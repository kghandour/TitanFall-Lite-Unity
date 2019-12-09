using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveAbility : MonoBehaviour
{
    private Animator anim;
    public GameObject sheild;
    private bool canActiveSheild = true;

    IEnumerator waitTwoSeconds(){
        yield return new WaitForSeconds(1.5f);
        sheild.gameObject.SetActive(true);
        anim.SetBool("onDefClick", false);
    }
    IEnumerator waitFiveSeconds(){
        yield return new WaitForSeconds(5f);
        sheild.gameObject.SetActive(false);
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
            if (Input.GetKeyDown(KeyCode.H))
            {
            anim.SetBool("onDefClick", true);
            StartCoroutine(waitTwoSeconds());
            StartCoroutine(waitFiveSeconds());
            canActiveSheild = false;
            StartCoroutine(waitFifteenSeconds());
            }
        }
        
    }
}
