using UnityEngine.AI;
using UnityEngine;

public class PreyBehavior : MonoBehaviour
{

    public Transform wolf;
    public float viewDistance = 15f;
    public float viewAngle = 90f; // field of view in degrees

    public bool canSeeWolf;
    private NavMeshAgent agent;
    public float fleeDistance = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        canSeeWolf = false;
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
            }
        }
    }


    
    
}
