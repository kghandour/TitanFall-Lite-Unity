using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanMov : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            {
            anim.SetBool("walk", true);
            anim.SetBool("NotWalking", false);
            }
         if (Input.GetKeyUp(KeyCode.W))
            {
            anim.SetBool("walk", false);
            anim.SetBool("NotWalking", true);
            }
    }
}
