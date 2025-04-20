using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public GameObject wolf;
    private Slider healthSlider;
    private float wolfHealth;
    public Image HealthFill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        // HealthFill = GetComponentInChildren<Image>();
        
        HealthFill.color = new Color(0.0f, 0.69f, 0.016f); //green
    }

    // Update is called once per frame
    void Update()
    {
        
        wolfHealth = wolf.GetComponent<PlayerBehavior>().health;
        healthSlider.value = wolfHealth;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {

        // float foodPercent = wolfFood / maxFood;
        // healthSlider.value = wolfHealth;

        if (wolfHealth  <= 1){
            HealthFill.color =  new Color(0.69f, 0.0f, 0.0f); //red
        } else if (wolfHealth  <= 2 && wolfHealth  > 1){
            HealthFill.color = new Color(0.68f, 0.40f, 0.02f); // orange
        } else{
            HealthFill.color = new Color(0.0f, 0.69f, 0.016f); ; //green
        }
    }
}
