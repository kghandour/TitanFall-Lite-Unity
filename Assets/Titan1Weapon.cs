using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan1Weapon : MonoBehaviour
{
    public GameObject bullet;

    public AudioSource source;
    public AudioClip fireSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            GameObject cloneObject;
            cloneObject = Instantiate(bullet, this.transform.position, this.transform.rotation);
            cloneObject.transform.Translate(Vector3.forward * 2.0f);
            //cloneObject.transform.Translate(Vector3.up * 2f);


            cloneObject.tag = "Primary";
            cloneObject.gameObject.GetComponent<Rigidbody>().velocity = this.transform.TransformDirection(Vector3.forward * 30);

            cloneObject = Instantiate(bullet, this.transform.position, this.transform.rotation);
            cloneObject.transform.Translate(Vector3.forward * 2.0f);
            //cloneObject.transform.Translate(Vector3.up * 2f);
            cloneObject.transform.Translate(Vector3.left * 0.7f);



            cloneObject.tag = "Primary";
            cloneObject.gameObject.GetComponent<Rigidbody>().velocity = this.transform.TransformDirection(Vector3.forward * 30);

            cloneObject = Instantiate(bullet, this.transform.position, this.transform.rotation);
            cloneObject.transform.Translate(Vector3.forward * 2.0f);
            //cloneObject.transform.Translate(Vector3.up * 2f);
            cloneObject.transform.Translate(Vector3.right * 0.7f);

            cloneObject.tag = "Primary";
            cloneObject.gameObject.GetComponent<Rigidbody>().velocity = this.transform.TransformDirection(Vector3.forward * 30);


            source.clip = fireSound;
            source.Play();
        }


    }

}
