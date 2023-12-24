using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaloryBar : MonoBehaviour
{

    private Slider slider;
    public TextMeshProUGUI text;
    public GameObject playerState;

    private float currnetCalory, maxCalory;
   
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currnetCalory = playerState.GetComponent<PlayerState>().currentCalory;
        maxCalory = playerState.GetComponent<PlayerState>().maxCalory;


        float fillValue = currnetCalory / maxCalory; //100/100 1  80/100 0.8
        slider.value = fillValue;
        text.text = Math.Round(currnetCalory, 1) + "/" + maxCalory.ToString();

    }
}
