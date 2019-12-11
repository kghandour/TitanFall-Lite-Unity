using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreAbility2 : MonoBehaviour
{
    private Animator anim;
    public GameObject Flame;
    private int canActiveFlame = 100;

    IEnumerator waitThreeSeconds(){
        yield return new WaitForSeconds(3f);
        anim.SetBool("onCoreClick", false);
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
            if (Input.GetKeyDown(KeyCode.B))
            {
            anim.SetBool("onCoreClick", true);
            StartCoroutine(waitThreeSeconds());
            canActiveFlame = 0;
            }
        }
    }
}
