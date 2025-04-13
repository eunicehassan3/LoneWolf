using Unity.Mathematics;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    private Rigidbody rb;
    private Vector3 moveInput;

    public float attackRange = 2f;
    private GameObject[] allPrey;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        allPrey = GameObject.FindGameObjectsWithTag("Prey");
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        float RotationInput = Input.GetAxisRaw("Horizontal");
        float moveInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space)){
            AttemptAttack();
        }

        rb.MovePosition(rb.position + transform.forward * Time.deltaTime * moveInput * moveSpeed);
        
        transform.Rotate(0f, RotationInput * rotationSpeed * Time.deltaTime, 0f);

        
        animator.SetBool("isMoving", moveInput != 0);
        animator.SetBool("isWalking", RotationInput != 0);
    }

    void AttemptAttack()
{
    GameObject[] allPrey = GameObject.FindGameObjectsWithTag("Prey");

    foreach (GameObject prey in allPrey)
    {
        if (prey == null) continue; // In case it's already destroyed

        float distance = Vector3.Distance(transform.position, prey.transform.position);
        if (distance <= attackRange)
        {
            PreyBehavior preyGameObject = prey.GetComponent<PreyBehavior>();
            if (preyGameObject != null && !preyGameObject.canSeeWolf)
            {
                Debug.Log("Sneak attack successful!");
                Destroy(prey.gameObject);
                return;
            }
            else
            {
                Debug.Log("Prey saw you! It runs!");
            }
        }
    }
}


//     void AttemptAttack()
//     {
//     GameObject[] allPrey = GameObject.FindGameObjectsWithTag("Prey");
//     foreach (GameObject prey in allPrey) {  
//     float distance = Vector3.Distance(transform.position, prey.transform.position);
//     if(distance <= attackRange){
//         PreyBehavior preyGameObject = prey.GetComponent<PreyBehavior>();
//         if (preyGameObject != null && !preyGameObject.canSeeWolf){
//             if (preyGameObject != null && !preyGameObject.canSeeWolf){
//                 Debug.Log("Sneak attack successful!");
//                 Destroy(prey.gameObject);
        
//             }
//             else{
//                 Debug.Log("Prey saw you! It runs!");}
//         }
//     }
// }
//     }
}
