using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PredatorBehavior : MonoBehaviour
{
    private Transform wolf;
    private Animator animator;
    public bool canSeeWolf;
    private NavMeshAgent agent;
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
    {   //bear is wandering around the forrest
        //if the bear is within a certain distance from the wolf/sees the wolf
        //then the bear should run toward the wolf 
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

     IEnumerator BehaviorLoop(){
        while (!canSeeWolf)
        {
            
            animator.SetBool("isEating", true);
            yield return new WaitForSeconds(3f); 
            animator.SetBool("isEating", false);
           
            Vector3 destination = GetRandomDestination();
            agent.SetDestination(destination);
            // while(transform.position != destination){
            //     animator.SetBool("isWalking", true);
            // }
            animator.SetBool("isWalking", true);
            agent.speed = 3.5f;
            

            while (Vector3.Distance(transform.position, destination) > 0.5f)
            {
                if (canSeeWolf) yield break;
                yield return null;
            }
        }

    } 
}
