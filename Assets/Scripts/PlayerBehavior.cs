using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
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

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space)){
            AttemptAttack();
        }

        moveInput = new Vector3(moveX, 0f, moveZ).normalized;
        // gameObject.transform.rotation = 

       bool isMoving = moveInput.magnitude > 0;
        animator.SetBool("isMoving", isMoving);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void AttemptAttack()
    {
        

    foreach (GameObject prey in allPrey){
    float distance = Vector3.Distance(transform.position, prey.transform.position);
    if(distance <= attackRange){
        PreyBehavior preyGameObject = prey.GetComponent<PreyBehavior>();
        if (preyGameObject != null && !preyGameObject.canSeeWolf){
            if (!preyGameObject.canSeeWolf){
                Debug.Log("Sneak attack successful!");
                Destroy(prey.gameObject);
        
            }
            else{
                Debug.Log("Prey saw you! It runs!");}
        }
    }
}
    }
}
