using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreAbility2 : MonoBehaviour
{
    private Animator anim;
    //public ParticleSystem Flame;
    public GameObject Flame;

    private int canActiveFlame = 100;

    IEnumerator waitThreeSeconds(){
        yield return new WaitForSeconds(2f);
        Flame.gameObject.SetActive(false);
        //Flame.enableEmission = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canActiveFlame == 100)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                Flame.gameObject.SetActive(true);
                //Flame.enableEmission = true;
                StartCoroutine(waitThreeSeconds());
            canActiveFlame = 0;
            }
        }
    }
}
