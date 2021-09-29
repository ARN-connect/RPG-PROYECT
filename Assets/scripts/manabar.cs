using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manabar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
    public static float maxManas;
    

	public void SetMaxMana(int maxmana)
	{
		slider.maxValue = maxmana;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetMana(int mana)
	{
		slider.value = mana;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

    public void maxManama(int maxMana)
	{
		maxManas = maxMana;
	}

    public void Update()
    {
        slider.maxValue = maxManas;
    }

}
