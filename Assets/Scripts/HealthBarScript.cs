using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{

    private Camera playerEyes;

    // Start is called before the first frame update
    void Start()
    {
        playerEyes = GameObject.FindGameObjectWithTag("LookAt").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Camera playerEyes = Camera.main;

        transform.LookAt(transform.position + playerEyes.transform.rotation * Vector3.back, playerEyes.transform.rotation * Vector3.up);

    }
}
