using UnityEngine;
using UnityEngine.UI;


public class FoodScript : MonoBehaviour
{
     public GameObject wolf;
    private Slider foodSlider;
    public Image foodFill; 
    private float wolfFood;
    private float maxFood;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foodSlider = GetComponent<Slider>();
        maxFood = wolfFood = wolf.GetComponent<PlayerBehavior>().maxFood;
        // foodFill = GetComponentInChildren<Image>();
        foodFill.color = new Color(0.0f, 0.69f, 0.016f); ; //green
        
        
    }

    // Update is called once per frame
    void Update()
    {
        wolfFood = wolf.GetComponent<PlayerBehavior>().FoodTimer();
        foodSlider.value = wolfFood;
        UpdateFoodUI();
    }

    void UpdateFoodUI()
    {
        float foodPercent = wolfFood / maxFood;
        // foodSlider.value = foodPercent;

        if (foodPercent < 0.2f){
            foodFill.color =  new Color(0.69f, 0.0f, 0.0f); //red
        } else if (foodPercent < 0.5f){
            foodFill.color = new Color(0.68f, 0.40f, 0.02f); // orange
        } else{
            foodFill.color = new Color(0.0f, 0.69f, 0.016f); ; //green
        }
    }
}
