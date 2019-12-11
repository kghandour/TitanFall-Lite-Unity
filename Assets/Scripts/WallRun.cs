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
            jump_count = 0;

            fp_rigidbody.useGravity = true;

            if (wall_right)
            {
                fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, -30);
            }
            else if (wall_left)
            {
                fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, 30);
            }

            wall_right = false;
            wall_left = false;
            fp_controller.m_wall_running = false;
        }

        if (
            Input.GetKey(KeyCode.W)
            && Input.GetKey(fp_controller.movementSettings.RunKey)
            && !fp_controller.Grounded
            && jump_count <= 0
            && fp_controller.m_Jumping > 0
            && !wall_left
            && !wall_right)
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitR, 1))
            {
                wall_right = true;
                jump_count += 1;
                fp_rigidbody.useGravity = false;
                fp_rigidbody.velocity = new Vector3(fp_rigidbody.velocity.x, 0, fp_rigidbody.velocity.z);
                fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, 30);
                fp_controller.m_wall_running = true;
            } else if (Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.right), out hitL, 1))
            {
                wall_left = true;
                jump_count += 1;
                fp_rigidbody.useGravity = false;
                fp_rigidbody.velocity = new Vector3(fp_rigidbody.velocity.x, 0, fp_rigidbody.velocity.z);
                fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, -30);
                fp_controller.m_wall_running = true;
            }
        } else if(
            jump_count >= 1
            && (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitR, 1)
            && !Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.right), out hitL, 1)
            || (!Input.GetKey(KeyCode.W)))
        )
        {
            fp_rigidbody.useGravity = true;

            if (wall_right)
            {
                fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, -30);
            }
            else if (wall_left)
            {
                fp_controller.mouseLook.LookRotation(fp_controller.transform, fp_camera.transform, 30);
            }

            wall_right = false;
            wall_left = false;
            fp_controller.m_wall_running = false;
        }
    }
}
