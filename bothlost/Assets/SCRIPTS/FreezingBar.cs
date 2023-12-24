using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FreezingBar : MonoBehaviour
{

    private Slider slider;
    public TextMeshProUGUI text;
    public GameObject playerState;

    private float currentFreezing, maxFreezing;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentFreezing = playerState.GetComponent<PlayerState>().currentFreezing;
        maxFreezing = playerState.GetComponent<PlayerState>().maxFreezing;


        float fillValue = currentFreezing / maxFreezing; //100/100 1  80/100 0.8
        slider.value = fillValue;
        text.text = Math.Round(currentFreezing, 1) + "/" + maxFreezing.ToString();

    }
}
