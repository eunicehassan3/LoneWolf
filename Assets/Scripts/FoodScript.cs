using UnityEngine;
using UnityEngine.UI;


public class FoodScript : MonoBehaviour
{
     public GameObject wolf;
    private Slider foodSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foodSlider = GetComponent<Slider>();
        // float wolfFood = wolf.GetComponent<PlayerBehavior>().FoodTimer();
        
    }

    // Update is called once per frame
    void Update()
    {
        float wolfFood = wolf.GetComponent<PlayerBehavior>().FoodTimer();
        foodSlider.value = wolfFood;
    }
}
