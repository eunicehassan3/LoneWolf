using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class PreyBehavior : MonoBehaviour{

    public Transform wolf;
    public float viewDistance = 15f;
    public float viewAngle = 90f; 

    public bool canSeeWolf;
    private NavMeshAgent agent;
    public float fleeDistance = 15f;
    private Animator preyAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        preyAnimator = GetComponent<Animator>();
        canSeeWolf = false;
        // preyAnimator.SetBool("isEating", true);
    }

    void Update()
    {
        SeeWolf();
        preyRunAway();

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
                    // Debug.Log("Prey has spotted wolf");
                    return;
                }
            }
        }

        canSeeWolf = false;

    }
     void preyRunAway(){
        if (canSeeWolf)
        {
            Vector3 directionAway = (transform.position - wolf.position).normalized;
            Vector3 fleeTarget = transform.position + directionAway * fleeDistance;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(fleeTarget, out hit, fleeDistance, NavMesh.AllAreas))
            {
                
                agent.SetDestination(hit.position);
                // preyAnimator.SetBool("isEating", false);
                preyAnimator.SetBool("isRunning", true);


            }


        }
    }

    IEnumerator BehaviorLoop(){
        while (!canSeeWolf)
        {
            
            preyAnimator.SetTrigger("Eat");
            yield return new WaitForSeconds(3f); 

           
            Vector3 destination = GetRandomDestination();
            agent.SetDestination(destination);
            preyAnimator.SetTrigger("Walk");

            while (Vector3.Distance(transform.position, destination) > 0.5f)
            {
                if (isSpotted) yield break;
                yield return null;
            }

    


    
    
}
