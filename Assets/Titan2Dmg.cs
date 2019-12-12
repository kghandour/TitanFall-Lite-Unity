using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan2Dmg : MonoBehaviour
{
    public GameObject fireArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject cloneObject;
        cloneObject = Instantiate(fireArea, this.transform.position, new Quaternion(0,0,0,0));
        Destroy(gameObject);
        //cloneObject.transform.Translate(Vector3.left * 1.1f);
        //cloneObject.transform.Translate(Vector3.up * 2f);


        //cloneObject.tag = "Primary";
        //cloneObject.gameObject.GetComponent<Rigidbody>().velocity = this.transform.TransformDirection(Vector3.left * 30);

    }

}
