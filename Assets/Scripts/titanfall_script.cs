using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titanfall_script : MonoBehaviour
{
    private Animator titanAnimator;

    // Start is called before the first frame update
    void Start()
    {
        titanAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            titanAnimator.SetTrigger("idle");
    }
}
