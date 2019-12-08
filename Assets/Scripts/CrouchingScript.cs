using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("isCrouching", true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("isCrouching", false);
        }
    }
}
