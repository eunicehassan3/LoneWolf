using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       mainCamera.transform.rotation = Quaternion.Euler(45,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
