using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public float maxStamina = 100f;
    public float currentStamina = 100f;
    public float StaminaReg = 0.1f;

    public Image Helthbar;
    public Image Staminabar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        if(currentStamina < maxStamina)
        {
            currentStamina += StaminaReg;
        }

        Helthbar.fillAmount = currentHealth / maxHealth;
        Staminabar.fillAmount = currentStamina / maxStamina;

	}
}
