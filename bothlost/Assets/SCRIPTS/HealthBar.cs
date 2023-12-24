using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider slider;
    public TextMeshProUGUI text;
    public GameObject playerState;

    private float currentHealth, maxHealth;
    
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerState.GetComponent<PlayerState>().currentHealth;
        maxHealth = playerState.GetComponent<PlayerState>().maxHealth;

        
        float fillValue = currentHealth / maxHealth; //100/100 1  80/100 0.8
        slider.value = fillValue;
        text.text = Math.Round(currentHealth, 1) + "/" + maxHealth.ToString();
    }
}
