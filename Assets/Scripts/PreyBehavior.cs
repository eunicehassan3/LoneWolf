using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PreyBehavior : MonoBehaviour
{

    public Transform wolf;
    public float viewDistance = 15f;
    public float viewAngle = 90f; // field of view in degrees

    public bool canSeeWolf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canSeeWolf = false;
    }

    void Update()
    {
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


    
    
}
