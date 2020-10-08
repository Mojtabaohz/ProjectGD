using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;
    public int currentHealth;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void TakeDamage(int damage){
        currentHealth -= damage;
        SetHealth(currentHealth);
        Debug.Log("damage Taken");
    }

    public void SetHealth(int health){
        slider.value = health; 
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Debug.Log("damage Applied");
    }




    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        SetHealth(currentHealth);
        fill.color = gradient.Evaluate(1f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
