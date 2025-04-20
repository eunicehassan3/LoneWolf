using UnityEngine;

public class MinimapScript : MonoBehaviour
{
     public Transform target;

    void LateUpdate()
    {
        Vector3 newPos = target.position;
        newPos.y = transform.position.y; 
        transform.position = newPos;
    }
}
