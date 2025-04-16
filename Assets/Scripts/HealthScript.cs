using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public GameObject wolf;
    private Slider healthSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float wolfHealth = wolf.GetComponent<PlayerBehavior>().health;
        healthSlider.value = wolfHealth;
    }
}
