using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WallRun : MonoBehaviour
{
    private RaycastHit hitR;
    private RaycastHit hitL;

    private int jump_count = 0;

    private RigidbodyFirstPersonController fp_controller;
    private Rigidbody fp_rigidbody;

    public Camera fp_camera;
    public float runTime;

    private bool wall_left = false;
    private bool wall_right = false;

    // Start is called before the first frame update
    void Start()
    {
        fp_controller = GetComponent<RigidbodyFirstPersonController>();
        fp_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fp_controller.Grounded)
        {
            Debug.Log("Grounded");
            jump_count = 0;
        }
        fp_camera.transform.Rotate(new Vector3(0, 0, 50));
        fp_controller.transform.Rotate(new Vector3(0, 0, 50));
        if (Input.GetKey(KeyCode.W) && !fp_controller.Grounded && jump_count <= 1)
        {
            Debug.Log("true 1");
            Debug.Log(jump_count);
            if(Physics.Raycast(transform.position, transform.right, out hitR, 1))
            {
                wall_right = true;
                jump_count += 1;
                fp_rigidbody.useGravity = false;
                fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, 15);
                StartCoroutine(afterRun());
            } else if (Physics.Raycast(transform.position, -transform.right, out hitL, 1))
            {
                wall_left = true;
                jump_count += 1;
                fp_rigidbody.useGravity = false;
                fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, -15);
                StartCoroutine(afterRun());
            }
        }
    }

    IEnumerator afterRun()
    {
        Debug.Log(runTime);
        yield return new WaitForSeconds(runTime);
        Debug.Log("after run");
        fp_rigidbody.useGravity = true;

        if(wall_right)
        {
            fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, -15);
        } else
        {
            fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, 15);
        }
    }
}
