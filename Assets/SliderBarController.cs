using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class SliderBarController : MonoBehaviour
{
    private HandStaminaProvider staminaProvider;
    private Slider slider;

    private void Start()
    {
        staminaProvider = GetComponentInParent<HandStaminaProvider>();
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        slider.value = staminaProvider.staminaCurrValue;
    }

}
