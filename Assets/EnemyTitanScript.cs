using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyTitanScript : MonoBehaviour
{

    protected NavMeshAgent enemy;
    protected StateEnum State;
    protected TargetScript[] potentialTargets;
    protected TargetScript target;
    protected TargetScript currentTarget;

    private float nextActionTime = 0.0f;
    private float period = 5f;
    private float firingPeriod = 3f;


    public Animator anim;
    private Animation anima;

    public GameObject player;
    public float allowedRange;
    public bool attackTrigger;

    public GameObject gun;

    private bool isFollowingFlag = true;
    private bool isWalkingFlag = true;




    //private IEnumerator WaitShwia(float shwia)
    //{
    //    //do
    //    //{
    //    //    yield return null;
    //    //} while (animation.isPlaying);

    //    yield return new WaitForSeconds(shwia);
    //}

    void FiringRoutine()
    {
        anim.SetBool("isFollowing", false);
        anim.SetBool("isFiring", true);
        //anim.SetBool("isFollowing", true);
        //anim.SetBool("isFiring", false);
        //anima.Play();
        ////WaitShwia(2.06f);
        //anim.SetBool("isFollowing", true);
        //anim.SetBool("isFiring", false);
        //anim.SetBool("isFiring", !anim.GetBool("isFiring"));
    }

    void WalkingRoutine()
    {
        anim.SetBool("isWalking", !anim.GetBool("isWalking"));
        anim.SetBool("isIdle", !anim.GetBool("isIdle"));
    }

    


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        anima = GetComponent<Animation>();
        potentialTargets = FindObjectsOfType<TargetScript>();
        target = potentialTargets[Random.Range(0, potentialTargets.Length)];
        InvokeRepeating("WalkingRoutine", 0, 5f);
        State = StateEnum.RUN;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < allowedRange && !anim.GetBool("isFollowing") && isFollowingFlag)
        {
            anim.SetBool("isFollowing", true);
            isWalkingFlag = false;
            isFollowingFlag = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            CancelInvoke();
            InvokeRepeating("FiringRoutine", 3f, 3f);
        }

        if (anim.GetBool("isFollowing") && !anim.GetBool("isFiring"))
        {
            enemy.destination = (player.transform.position);
            //transform.position += enemy.desiredVelocity * Time.deltaTime;
        }

        if (anim.GetBool("isFiring"))
        {
            enemy.destination = transform.position;
            //gun.transform.LookAt(transform.InverseTransformDirection(Vector3.forward)); 
        }

        if (anim.GetBool("isWalking"))
        {
            if (enemy.desiredVelocity.magnitude < 0.1f && !enemy.pathPending)
            {
                target = potentialTargets[Random.Range(0, potentialTargets.Length)];
                enemy.destination = (target.transform.position);
            }
            //transform.position += enemy.desiredVelocity * Time.deltaTime;
        }

        if (anim.GetBool("isIdle"))
        {
            enemy.destination = (transform.position);
        }     
    }

    

    

    public enum StateEnum
    {
        RUN,
        //SHOOT
    }
}
