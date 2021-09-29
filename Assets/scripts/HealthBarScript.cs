using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
    public static float maxLives;
    

	public void SetMaxHealth(int maxhealth)
	{
		slider.maxValue = maxhealth;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(int health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

    public void maxLive(int maxHealth)
	{
		maxLives = maxHealth;
	}

    public void Update()
    {
        slider.maxValue = maxLives;
    }

}