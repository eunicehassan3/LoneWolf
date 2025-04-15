using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PredatorBehavior : MonoBehaviour
{
    private Transform wolf;
    private Animator animator;
    public bool canSeeWolf;
    private NavMeshAgent agent;
    public float viewDistance = 15f;
    public float viewAngle = 90f; 
    public float attackRange = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        wolf = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(BehaviorLoop());
    }

    // Update is called once per frame
    void Update()
    {   
        //bear is wandering around the forrest
        //if the bear is within a certain distance from the wolf/sees the wolf
        SeeWolf();
        //then the bear should run toward the wolf 
        AttackWolf();
        //if the bear is able to reach the wolf, then it dies 
        //[OPTIONAL IMPLEMENTATION: instead of the just dying like that -- a bear attack wounds wolf but doesn't kill it, 3-4 wounds will kill the wolf]
        //if the wolf gets out of the reach  of the bear, then the bear continues wondering the forrest
    }

    Vector3 GetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 5;
        randomDirection += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 5, 1);
        return hit.position;
    }

    //  IEnumerator BehaviorLoop(){
    //     while (!canSeeWolf)
    //     {
            
    //         animator.SetBool("isEating", true);
    //         yield return new WaitForSeconds(3f); 
    //         animator.SetBool("isEating", false);
           
    //         Vector3 destination = GetRandomDestination();
    //         agent.SetDestination(destination);
    //         // while(transform.position != destination){
    //         //     animator.SetBool("isWalking", true);
    //         // }
    //         animator.SetBool("isWalking", true);
    //         agent.speed = 3.5f;
            

    //         while (Vector3.Distance(transform.position, destination) > 0.5f)
    //         {
    //             if (canSeeWolf) yield break;
    //             yield return null;
    //         }
    //     }
    // } 

    IEnumerator BehaviorLoop()
    {
        while (!canSeeWolf)
        {
            animator.SetBool("isEating", true);
            yield return new WaitForSeconds(3f);
            animator.SetBool("isEating", false);

            Vector3 destination = GetRandomDestination();
            agent.SetDestination(destination);
            agent.speed = 3.5f;

            animator.SetBool("isWalking", true);

            while (Vector3.Distance(transform.position, destination) > 0.5f)
            {
                if (canSeeWolf) yield break;
                yield return null;
            }

            animator.SetBool("isWalking", false);

            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }



    void SeeWolf(){
            Vector3 directionToWolf = wolf.position - transform.position;
            float angleToWolf = Vector3.Angle(transform.forward, directionToWolf);

            if (directionToWolf.magnitude < viewDistance && angleToWolf < viewAngle / 2f)
            {
                
                if (Physics.Raycast(transform.position, directionToWolf.normalized, out RaycastHit hit, viewDistance))
                {
                    if (hit.transform == wolf)
                    {
                        canSeeWolf = true;
                        Debug.Log("Predator can see wolf");
                        return;
                    }
                }
            }

            canSeeWolf = false;
            animator.SetBool("isWalking", false);


        }


    void AttackWolf()
{
    if (canSeeWolf)
    {
        agent.SetDestination(wolf.position);
        agent.speed = 10f;

        float distance = Vector3.Distance(transform.position, wolf.position);

        if (distance > attackRange)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetTrigger("Attack");
        }
    }
    else
    {
        // Only stop running if we’ve lost sight
        animator.SetBool("isRunning", false);
    }
}
}
