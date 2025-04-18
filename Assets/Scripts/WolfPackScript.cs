using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfPackScript : MonoBehaviour
{
    private Transform wolf;
    public float viewDistance = 15f;
    public float viewAngle = 90f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wolf = GameObject.FindWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SeeWolf();
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
                    // Debug.Log("You found the wolf pack");
                    SceneManager.LoadScene("Win");
                    
                    return;
                }
            }
        }

        

    }
}
