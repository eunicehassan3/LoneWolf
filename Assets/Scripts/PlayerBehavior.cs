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
    public float health = 5;
    public float food = 0;
    private float totalMin = 120;


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
            animator.SetTrigger("Attack");
            AttemptAttack();
        }

        rb.MovePosition(rb.position + transform.forward * Time.deltaTime * moveInput * moveSpeed);
        
        transform.Rotate(0f, RotationInput * rotationSpeed * Time.deltaTime, 0f);

        
        animator.SetBool("isMoving", moveInput != 0);
        animator.SetBool("isWalking", RotationInput != 0);

        if(health <= 0){
            animator.SetBool("isDead", true);
            Debug.Log("Game Over"); 
            }

        FoodTimer();
        
               
        }

    void AttemptAttack(){
        GameObject[] allPrey = GameObject.FindGameObjectsWithTag("Prey");

        foreach (GameObject prey in allPrey)
        {
            if (prey == null) continue;

            float distance = Vector3.Distance(transform.position, prey.transform.position);
            if (distance <= attackRange)
            {
                PreyBehavior preyGameObject = prey.GetComponent<PreyBehavior>();
                if (preyGameObject != null && !preyGameObject.canSeeWolf)
                {
                    Debug.Log("Sneak attack successful!");
                    food += 10;


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

    public void TakeDamage(float damageAmount){
        health -= damageAmount;
    }

    public float FoodTimer(){
        totalMin -= 1 * Time.deltaTime;
        

        if(totalMin <= 0){
            Debug.Log("Game Over");
        }
        return totalMin;
    }
    

}
